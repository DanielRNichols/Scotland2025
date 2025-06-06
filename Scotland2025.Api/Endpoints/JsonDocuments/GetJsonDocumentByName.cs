using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Api.Endpoints;
using Scotland2025.Api.Endpoints.JsonDocuments;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.JsonDocuments;

namespace Scotland2025.Api.Endpoints.JsonDocuments;

public static class GetJsonDocumentByName
{
    //public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static Contracts.JsonDocuments.GetJsonDocumentByName.Response ToGetJsonDocumentByNameResponse(this JsonDocument result)
    {
        return new Contracts.JsonDocuments.GetJsonDocumentByName.Response(result.Id, result.DocumentName, result.JsonValue, result.LastModified);
    }

    public sealed class GetJsonDocumentByIdEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/jsonDocuments/find/{documentName}", HandleGetJsonDocumentByName)
                .WithName(nameof(GetJsonDocumentByName))
                .WithSummary("Get JsonDocument by Name");
                //.AddEndpointFilter<IdValidationFilter>();
        }
    }

    public static async Task<Results<Ok<Contracts.JsonDocuments.GetJsonDocumentByName.Response>, ProblemHttpResult>> HandleGetJsonDocumentByName(string documentName, ISender sender, CancellationToken cancellationToken)
    {
        var getJsonDocumentByIdQuery = new GetJsonDocumentByNameQuery(documentName);
        var result = await sender.Send(getJsonDocumentByIdQuery, cancellationToken);
        return result.Match<Results<Ok<Contracts.JsonDocuments.GetJsonDocumentByName.Response>, ProblemHttpResult>>(
            jsonDocument => TypedResults.Ok(jsonDocument.ToGetJsonDocumentByNameResponse()),
            errors => errors.ToProblemHttpResult()
        );
    }
}


