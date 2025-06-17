using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.Abstractions.Commands;
using Scotland2025.Application.Abstractions.DatesAndTime;
using Scotland2025.Application.Common.Errors;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.JsonDocuments;

public record CreateJsonDocumentCommand(string DocumentName, string JsonValue) : ICommand<ErrorOr<JsonDocument>>;

public class CreateJsonDocumentCommandHandler : ICommandHandler<CreateJsonDocumentCommand, ErrorOr<JsonDocument>>
{
    private readonly Scotland2025DbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateJsonDocumentCommandHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<JsonDocument>> Handle(CreateJsonDocumentCommand command, CancellationToken cancellationToken)
    {
        var jsonDocument = JsonDocument.Create(command.DocumentName, command.JsonValue, _dateTimeProvider.UtcNow);

        var existingJsonDocument = await GetJsonDocumentByNameAsync(jsonDocument.DocumentName, cancellationToken);
        if (existingJsonDocument is not null)
        {
            return ApplicationErrors.JsonDocuments.Conflict(jsonDocument.DocumentName);
        }

        _dbContext.JsonDocuments.Add(jsonDocument);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result == 0)
        {
            return Error.Failure($"Unable to add {jsonDocument.DocumentName}");
        }

        return jsonDocument;
    }

    private async Task<JsonDocument?> GetJsonDocumentByNameAsync(string documentName, CancellationToken cancellationToken)
    {
        return await _dbContext.JsonDocuments.AsNoTracking().FirstOrDefaultAsync(x => x.DocumentName == documentName, cancellationToken);
    }
}
