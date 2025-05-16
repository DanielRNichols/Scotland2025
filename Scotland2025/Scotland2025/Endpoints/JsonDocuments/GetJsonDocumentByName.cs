using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.JsonDocuments;

namespace Scotland2025.Endpoints.JsonDocuments;

public static class GetJsonDocumentByName
{
    public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static Response ToGetJsonDocumentByNameResponse(this JsonDocument result)
    {
        return new Response(result.Id, result.DocumentName, result.JsonValue, result.LastModified);
    }

    public sealed class GetJsonDocumentByIdEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/jsonDocuments/{documentName:alpha}", HandleGetJsonDocumentByName)
                .WithName(nameof(GetJsonDocumentByName))
                .WithSummary("Get JsonDocument by Name");
                //.AddEndpointFilter<IdValidationFilter>();
        }
    }

    public static async Task<Results<Ok<Response>, ProblemHttpResult>> HandleGetJsonDocumentByName(string documentName, ISender sender, CancellationToken cancellationToken)
    {
        var getJsonDocumentByIdQuery = new GetJsonDocumentByNameQuery(documentName);
        var result = await sender.Send(getJsonDocumentByIdQuery, cancellationToken);
        return result.Match<Results<Ok<Response>, ProblemHttpResult>>(
            jsonDocument => TypedResults.Ok(jsonDocument.ToGetJsonDocumentByNameResponse()),
            errors => errors.ToProblemHttpResult()
        );
    }
}


