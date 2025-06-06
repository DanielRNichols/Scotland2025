using FluentValidation;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.JsonDocuments;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Api.Filters;
using Scotland2025.Api.Endpoints;

namespace Scotland2025.Api.Endpoints.JsonDocuments;

public static class DeleteJsonDocument
{
    public sealed class DeleteJsonDocumentEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapDelete("/api/jsonDocuments/{documentName}", HandleDeleteJsonDocument).WithTags("JsonDocuments")
                .WithName(nameof(DeleteJsonDocument))
                .WithSummary("Delete JsonDocument");
                //.AddEndpointFilter<IdValidationFilter>();
        }
    }

    public static async Task<Results<NoContent, ProblemHttpResult>> HandleDeleteJsonDocument(string documentName, ISender sender)
    {
        var deleteJsonDocumentCommand = new DeleteJsonDocumentCommand(documentName);
        var result = await sender.Send(deleteJsonDocumentCommand);
        return result.Match<Results<NoContent, ProblemHttpResult>>(
            _ => TypedResults.NoContent(),
            errors => errors.ToProblemHttpResult()
        );
    }
}


