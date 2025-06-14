using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.Images;

namespace Scotland2025.Api.Endpoints.Images;

public static class GetImages
{
    //public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static Contracts.Images.GetImages.Response ToGetImageResponse(this Image result)
    {
        return new Contracts.Images.GetImages.Response(result.Id, result.Url, result.Description, result.DateAdded, result.AddedBy);
    }

    public sealed class GetImagesEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/images", HandleGetImages).WithTags("Images")
               .WithName(nameof(GetImages))
               .WithSummary("Get Images");
        }
    }

    public static async Task<Results<Ok<List<Contracts.Images.GetImages.Response>>, ProblemHttpResult>> HandleGetImages(ISender sender, CancellationToken cancellationToken)
    {
        var getImagesQuery = new GetImagesQuery();
        var result = await sender.Send(getImagesQuery, cancellationToken);

        return result.Match<Results<Ok<List<Contracts.Images.GetImages.Response>>, ProblemHttpResult>>(
            images => TypedResults.Ok(images.Select(x => x.ToGetImageResponse()).ToList()),
            errors => errors.ToProblemHttpResult() //TypedResults.Problem(statusCode: StatusCodes.Status500InternalServerError, title: errors[0].Description)
        );
    }

}


