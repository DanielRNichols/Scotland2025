using ErrorOr;
using Scotland2025.Application.Abstractions.Commands;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.Abstractions.DatesAndTime;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.Images;
public record UpdateImageCommand(int Id, string Url, string? Description, DateTime? DateAdded, string? AddedBy) : ICommand<ErrorOr<Image>>;

public class UpdateImageCommandHandler : ICommandHandler<UpdateImageCommand, ErrorOr<Image>>
{
    private readonly Scotland2025DbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UpdateImageCommandHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Image>> Handle(UpdateImageCommand command, CancellationToken cancellationToken)
    {
        var existingImage = await GetImageByIdAsync(command.Id, cancellationToken);

        Image image;

        if (existingImage is null)
        {
            image = Image.Create(command.Url, command.Description, _dateTimeProvider.UtcNow, command.AddedBy);
            _dbContext.Images.Add(image);
        }
        else
        {
            image = Image.Create(existingImage.Id, command.Url, command.Description, _dateTimeProvider.UtcNow, command.AddedBy);
            _dbContext.Images.Update(image);
        }

        var result = await _dbContext.SaveChangesAsync(cancellationToken);

        if (result == 0)
        {
            return Error.Failure($"Unable to update {image.Url}");
        }

        return image;
    }

    private async Task<Image?> GetImageByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Images.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

}
