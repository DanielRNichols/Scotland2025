using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.Abstractions.Commands;
using Scotland2025.Application.Abstractions.DatesAndTime;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.Images;

public record CreateImageCommand(string Url, string? Description, string? AddedBy) : ICommand<ErrorOr<Image>>;

public class CreateJsonDocumentCommandHandler : ICommandHandler<CreateImageCommand, ErrorOr<Image>>
{
    private readonly Scotland2025DbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateJsonDocumentCommandHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Image>> Handle(CreateImageCommand command, CancellationToken cancellationToken)
    {
        var image = Image.Create(command.Url, command.Description, _dateTimeProvider.UtcNow, command.AddedBy);

        var existingImage = await GetImageByUrlAsync(command.Url, cancellationToken);
        if (existingImage is not null)
        {
            return ApplicationErrors.Images.Conflict(command.Url);
        }

        _dbContext.Images.Add(image);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result == 0)
        {
            return Error.Failure($"Unable to add {image.Url}");
        }

        return image;
    }

    private async Task<Image?> GetImageByUrlAsync(string url, CancellationToken cancellationToken)
    {
        return await _dbContext.Images.AsNoTracking().FirstOrDefaultAsync(x => x.Url == url, cancellationToken);
    }
}
