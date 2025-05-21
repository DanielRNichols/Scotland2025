using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Application.JsonDocuments;
using Scotland2025.Api.Extensions;
using Scotland2025.Api.Filters;
using Scotland2025.Api.Endpoints;
using Scotland2025.Api.Endpoints.JsonDocuments;
using Scotland2025.Contracts.JsonDocuments;

namespace Scotland2025.Api.Endpoints.JsonDocuments;

public static class CreateJsonDocument
{
    //public record Request(string DocumentName, string JsonValue);

    //public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static CreateJsonDocumentCommand ToCreateJsonDocumentCommand(this Contracts.JsonDocuments.CreateJsonDocument.Request request)
    {
        return new CreateJsonDocumentCommand(request.DocumentName, request.JsonValue);
    }

    public static Contracts.JsonDocuments.CreateJsonDocument.Response ToCreateJsonDocumentResponse(this JsonDocument result)
    {
        return new Contracts.JsonDocuments.CreateJsonDocument.Response(result.Id, result.DocumentName, result.JsonValue, result.LastModified);
    }

    public sealed class CreateJsonDocumentEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/jsonDocuments", HandleCreateJsonDocument).WithTags("JsonDocuments")
                .WithName(nameof(CreateJsonDocument))
                .WithOpenApi()
                .WithSummary("Create JsonDocument");
                //.AddEndpointFilter<RequestValidationFilter<Request>>();
        }
    }

    public static async Task<Results<Created<Contracts.JsonDocuments.CreateJsonDocument.Response>, ProblemHttpResult>> HandleCreateJsonDocument(Contracts.JsonDocuments.CreateJsonDocument.Request req, ISender sender, LinkGenerator linkGenerator, HttpContext httpContext, CancellationToken cancellationToken)
    {
        var createJsonDocumentCommand = req.ToCreateJsonDocumentCommand();
        var result = await sender.Send(createJsonDocumentCommand);
        return result.Match<Results<Created<Contracts.JsonDocuments.CreateJsonDocument.Response>, ProblemHttpResult>>(
            jsonDocument =>
            {
                var url = linkGenerator.GetPathByName(httpContext, "GetJsonDocumentById", new { id = jsonDocument.Id });
                return TypedResults.Created(url, jsonDocument.ToCreateJsonDocumentResponse());
            },
            errors => errors.ToProblemHttpResult()
        );
    }
}


