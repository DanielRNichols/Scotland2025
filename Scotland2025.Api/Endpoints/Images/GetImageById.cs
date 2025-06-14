using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.Images;

namespace Scotland2025.Api.Endpoints.Images;

public static class GetImageById
{
    public static Contracts.Images.GetImageById.Response ToGetImageByIdResponse(this Image result)
    {
        return new Contracts.Images.GetImageById.Response(result.Id, result.Url, result.Description, result.DateAdded, result.AddedBy);
    }

    public sealed class GetImageByIdEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/images/{id:int}", HandleGetImageById)
                .WithName(nameof(GetImageById))
                .WithSummary("Get Image by Id");
            //    .AddEndpointFilter<IdValidationFilter>();
        }
    }

    public static async Task<Results<Ok<Contracts.Images.GetImageById.Response>, ProblemHttpResult>> HandleGetImageById(int id, ISender sender, CancellationToken cancellationToken)
    {
        var getImageByIdQuery = new GetImageByIdQuery(id);
        var result = await sender.Send(getImageByIdQuery, cancellationToken);
        return result.Match<Results<Ok<Contracts.Images.GetImageById.Response>, ProblemHttpResult>>(
            image => TypedResults.Ok(image.ToGetImageByIdResponse()),
            errors => errors.ToProblemHttpResult()
        );
    }
}


