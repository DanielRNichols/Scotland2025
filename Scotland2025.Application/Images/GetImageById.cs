using ErrorOr;
using Scotland2025.Application.Abstractions.Data;
using Scotland2025.Application.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Scotland2025.Application.Images;
public record GetImageByIdQuery(int Id) : IQuery<ErrorOr<Image>>;

public class GetImageByIdQueryHandler : IQueryHandler<GetImageByIdQuery, ErrorOr<Image>>
{
    private readonly IScotland2025DbContext _dbContext;

    public GetImageByIdQueryHandler(IScotland2025DbContext dbContext)
    {
        _dbContext = dbContext;
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
