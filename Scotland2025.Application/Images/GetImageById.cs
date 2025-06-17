using ErrorOr;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.Images;
public record GetImageByIdQuery(int Id) : IQuery<ErrorOr<Image>>;

public class GetImageByIdQueryHandler : IQueryHandler<GetImageByIdQuery, ErrorOr<Image>>
{
    private readonly Scotland2025DbContext _dbContext;

    public GetImageByIdQueryHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public async Task<ErrorOr<Image>> Handle(GetImageByIdQuery query, CancellationToken cancellationToken)
    {
        var image = await _dbContext.Images.AsNoTracking().FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        if (image is null)
        {
            //throw new NotFoundException($"Image with id {query.Id} not found");
            return ApplicationErrors.Images.NotFound(query.Id);
        }

        return image;
    }
}
