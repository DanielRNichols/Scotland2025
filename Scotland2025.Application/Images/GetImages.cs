using ErrorOr;
using Scotland2025.Application.Abstractions.Data;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Scotland2025.Application.Images;
public record GetImagesQuery() : IQuery<ErrorOr<IList<Image>>>;

public class GetImagesQueryHandler : IQueryHandler<GetImagesQuery, ErrorOr<IList<Image>>>
{
    private readonly IScotland2025DbContext _dbContext;

    public GetImagesQueryHandler(IScotland2025DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ErrorOr<IList<Image>>> Handle(GetImagesQuery request, CancellationToken cancellationToken)
    {
        var images = await _dbContext.Images.AsNoTracking().ToListAsync(cancellationToken);
        return images;
    }
}
