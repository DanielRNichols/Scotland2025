using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.Images;

namespace Scotland2025.Api.Endpoints.Images;

public static class DeleteImage
{
    public sealed class DeleteImageEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapDelete("/api/images/{id}", HandleDeleteImage).WithTags("Images")
                .WithName(nameof(DeleteImage))
                .WithSummary("Delete Image");
                //.AddEndpointFilter<IdValidationFilter>();
        }
    }

    public static async Task<Results<NoContent, ProblemHttpResult>> HandleDeleteImage(int id, ISender sender)
    {
        var deleteImageCommand = new DeleteImageCommand(id);
        var result = await sender.Send(deleteImageCommand);
        return result.Match<Results<NoContent, ProblemHttpResult>>(
            _ => TypedResults.NoContent(),
            errors => errors.ToProblemHttpResult()
        );
    }
}


