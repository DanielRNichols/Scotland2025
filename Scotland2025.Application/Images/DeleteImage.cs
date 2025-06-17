using ErrorOr;
using Scotland2025.Application.Abstractions.Commands;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.Images;
public record DeleteImageCommand(int Id) : ICommand<ErrorOr<Success>>;
public class DeleteImageCommandHandler : ICommandHandler<DeleteImageCommand, ErrorOr<Success>>
{
    private readonly Scotland2025DbContext _dbContext;

    public DeleteImageCommandHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public async Task<ErrorOr<Success>> Handle(DeleteImageCommand req, CancellationToken cancellationToken)
    {
        var image = await GetImageByIdAsync(req.Id, cancellationToken);
        if (image is null)
        {
            return ApplicationErrors.Images.NotFound(req.Id);
        }
        _dbContext.Images.Remove(image);
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (result == 0)
        {
            return Error.Failure($"Unable to delete {image.Url}");
        }

        return Result.Success;
    }

    private async Task<Image?> GetImageByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Images.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }


}

