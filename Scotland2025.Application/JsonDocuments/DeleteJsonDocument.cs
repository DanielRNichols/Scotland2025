﻿using ErrorOr;
using Scotland2025.Application.Abstractions.Commands;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.JsonDocuments;
public record DeleteJsonDocumentCommand(string DocumentName) : ICommand<ErrorOr<Success>>;
public class DeleteJsonDocumentCommandHandler : ICommandHandler<DeleteJsonDocumentCommand, ErrorOr<Success>>
{
    private readonly Scotland2025DbContext _dbContext;

    public DeleteJsonDocumentCommandHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public async Task<ErrorOr<Success>> Handle(DeleteJsonDocumentCommand req, CancellationToken cancellationToken)
    {
        var jsondocument = await GetJsonDocumentByNameAsync(req.DocumentName, cancellationToken);
        if (jsondocument is null)
        {
            return ApplicationErrors.JsonDocuments.NotFound(req.DocumentName);
        }
        _dbContext.JsonDocuments.Remove(jsondocument);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result == 0)
        {
            return Error.Failure($"Unable to delete {jsondocument.DocumentName}");
        }

        return Result.Success;
    }

    private async Task<JsonDocument?> GetJsonDocumentByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.JsonDocuments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    private async Task<JsonDocument?> GetJsonDocumentByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.JsonDocuments.AsNoTracking().FirstOrDefaultAsync(x => x.DocumentName == name.ToLower(), cancellationToken);
    }


}

