using ErrorOr;
using MediatR;
using Scotland2025.Abstractions.Data;
using Scotland2025.Application.Abstractions.JsonOptions;
using Scotland2025.Application.Images;
using Scotland2025.Application.JsonDocuments;
using Scotland2025.Models;
using System.Text.Json;

namespace Scotland2025.Services.Data;
public class ImagesDataService : IImagesDataService
{
    private readonly ISender _sender;

    public ImagesDataService(ISender sender)
    {
        _sender = sender;
    }
    public async Task<IList<Image>> GetAsync(CancellationToken cancellationToken = default)
    {
        var getImagesQuery = new GetImagesQuery();
        var result = await _sender.Send(getImagesQuery, cancellationToken);

        if (result.IsError)
        {
            return new List<Image>();
        }

        return result.Value;
    }
}

