using ErrorOr;
using Scotland2025.Application.Abstractions.Commands;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.Abstractions.DatesAndTime;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.JsonDocuments;
public record UpdateJsonDocumentCommand(string DocumentName, string JsonValue) : ICommand<ErrorOr<JsonDocument>>;

public class UpdateJsonDocumentCommandHandler : ICommandHandler<UpdateJsonDocumentCommand, ErrorOr<JsonDocument>>
{
    private readonly Scotland2025DbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UpdateJsonDocumentCommandHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<JsonDocument>> Handle(UpdateJsonDocumentCommand command, CancellationToken cancellationToken)
    {
        var existingJsonDocument = await GetJsonDocumentByNameAsync(command.DocumentName, cancellationToken);

        JsonDocument jsonDocument;

        if (existingJsonDocument is null)
        {
            jsonDocument = JsonDocument.Create(command.DocumentName, command.JsonValue, _dateTimeProvider.UtcNow);
            _dbContext.JsonDocuments.Add(jsonDocument);
        }
        else
        {
            jsonDocument = JsonDocument.Create(existingJsonDocument.Id, command.DocumentName, command.JsonValue, _dateTimeProvider.UtcNow);
            _dbContext.JsonDocuments.Update(jsonDocument);
        }

        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result == 0)
        {
            return Error.Failure($"Unable to update {jsonDocument.DocumentName}");
        }

        return jsonDocument;
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
