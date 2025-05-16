using FluentValidation;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.JsonDocuments;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Endpoints.JsonDocuments;
using Scotland2025.Filters;

namespace Scotland2025.Endpoints.JsonDocuments;

public static class GetJsonDocumentById
{
    public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static Response ToGetJsonDocumentByIdResponse(this JsonDocument result)
    {
        return new Response(result.Id, result.DocumentName, result.JsonValue, result.LastModified);
    }

    public sealed class GetJsonDocumentByIdEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/jsonDocuments/{id:int}", HandleGetJsonDocumentById)
                .WithName(nameof(GetJsonDocumentById))
                .WithSummary("Get JsonDocument by Id");
            //    .AddEndpointFilter<IdValidationFilter>();
        }
    }

    public static async Task<Results<Ok<Response>, ProblemHttpResult>> HandleGetJsonDocumentById(int id, ISender sender, CancellationToken cancellationToken)
    {
        var getJsonDocumentByIdQuery = new GetJsonDocumentByIdQuery(id);
        var result = await sender.Send(getJsonDocumentByIdQuery, cancellationToken);
        return result.Match<Results<Ok<Response>, ProblemHttpResult>>(
            jsonDocument => TypedResults.Ok(jsonDocument.ToGetJsonDocumentByIdResponse()),
            errors => errors.ToProblemHttpResult()
        );
    }
}


