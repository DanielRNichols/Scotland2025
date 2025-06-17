using ErrorOr;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using Scotland2025.Application.DbContexts;

namespace Scotland2025.Application.Images;
public record GetImagesQuery() : IQuery<ErrorOr<IList<Image>>>;

public class GetImagesQueryHandler : IQueryHandler<GetImagesQuery, ErrorOr<IList<Image>>>
{
    private readonly Scotland2025DbContext _dbContext;

    public GetImagesQueryHandler(IDbContextFactory<Scotland2025DbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext() ;
    }

    public async Task<ErrorOr<IList<Image>>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
    {
        var images = await _dbContext.Images.AsNoTracking().ToListAsync(cancellationToken);
        return images;
    }
}
