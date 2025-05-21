using FluentValidation;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.JsonDocuments;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Api.Endpoints;
using Scotland2025.Api.Endpoints.JsonDocuments;

namespace Scotland2025.Api.Endpoints.JsonDocuments;

public static class GetJsonDocuments
{
    //public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static Contracts.JsonDocuments.GetJsonDocuments.Response ToGetJsonDocumentResponse(this JsonDocument result)
    {
        return new Contracts.JsonDocuments.GetJsonDocuments.Response(result.Id, result.DocumentName, result.JsonValue, result.LastModified);
    }

    public sealed class GetJsonDocumentsEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/jsonDocuments", HandleGetJsonDocuments).WithTags("JsonDocuments")
               .WithName(nameof(GetJsonDocuments))
               .WithSummary("Get JsonDocuments");
        }
    }

    public static async Task<Results<Ok<List<Contracts.JsonDocuments.GetJsonDocuments.Response>>, ProblemHttpResult>> HandleGetJsonDocuments(ISender sender, CancellationToken cancellationToken)
    {
        var getJsonDocumentsQuery = new GetJsonDocumentsQuery();
        var result = await sender.Send(getJsonDocumentsQuery, cancellationToken);

        return result.Match<Results<Ok<List<Contracts.JsonDocuments.GetJsonDocuments.Response>>, ProblemHttpResult>>(
            jsonDocuments => TypedResults.Ok(jsonDocuments.Select(x => x.ToGetJsonDocumentResponse()).ToList()),
            errors => errors.ToProblemHttpResult() //TypedResults.Problem(statusCode: StatusCodes.Status500InternalServerError, title: errors[0].Description)
        );
    }

}


