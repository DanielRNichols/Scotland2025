using ErrorOr;
using Scotland2025.Application.Images;
using Scotland2025.Models;

namespace Scotland2025.Abstractions.Data;
public interface IImagesDataService
{
    Task<IList<Image>> GetAsync(CancellationToken cancellationToken = default);



}
