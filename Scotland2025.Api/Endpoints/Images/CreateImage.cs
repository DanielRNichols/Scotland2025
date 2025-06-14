using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Application.JsonDocuments;
using Scotland2025.Api.Extensions;
using Scotland2025.Api.Filters;
using Scotland2025.Api.Endpoints;
using Scotland2025.Api.Endpoints.JsonDocuments;
using Scotland2025.Contracts.JsonDocuments;
using Scotland2025.Application.Images;

namespace Scotland2025.Api.Endpoints.JsonDocuments;

public static class CreateImage
{

    public static CreateImageCommand ToCreateImageCommand(this Contracts.Images.CreateImage.Request request)
    {
        return new CreateImageCommand(request.Url, request.Description, request.AddedBy);
    }

    public static Contracts.Images.CreateImage.Response ToCreateImageResponse(this Image result)
    {
        return new Contracts.Images.CreateImage.Response(result.Id, result.Url, result.Description, result.DateAdded, result.AddedBy);
    }

    public sealed class CreateImageEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/images", HandleCreateImage).WithTags("Images")
                .WithName(nameof(CreateImage))
                .WithOpenApi()
                .WithSummary("Create Image");
                //.AddEndpointFilter<RequestValidationFilter<Request>>();
        }
    }

    public static async Task<Results<Created<Contracts.Images.CreateImage.Response>, ProblemHttpResult>> HandleCreateImage(Contracts.Images.CreateImage.Request req, ISender sender, LinkGenerator linkGenerator, HttpContext httpContext, CancellationToken cancellationToken)
    {
        var createImageCommand = req.ToCreateImageCommand();
        var result = await sender.Send(createImageCommand);
        return result.Match<Results<Created<Contracts.Images.CreateImage.Response>, ProblemHttpResult>>(
            image =>
            {
                var url = linkGenerator.GetPathByName(httpContext, "GetImageById", new { id = image.Id });
                return TypedResults.Created(url, image.ToCreateImageResponse());
            },
            errors => errors.ToProblemHttpResult()
        );
    }
}


