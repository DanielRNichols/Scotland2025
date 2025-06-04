using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Application.JsonDocuments;
using Scotland2025.Endpoints.JsonDocuments;
using Scotland2025.Filters;
using Scotland2025.Extensions;

namespace Scotland2025.Endpoints.JsonDocuments;

public static class UpdateJsonDocument
{
    public record Request(string JsonValue);

    public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static UpdateJsonDocumentCommand ToUpdateJsonDocumentCommand(this Request req, string documentName)
    {
        return new UpdateJsonDocumentCommand(documentName, req.JsonValue);
    }
    public static Response ToUpdateJsonDocumentResponse(this JsonDocument result)
    {
        return new Response(result.Id, result.DocumentName, result.JsonValue, result.LastModified);
    }

    public class UpdateJsonDocumentRequestValidator : AbstractValidator<Request>
    {
        public UpdateJsonDocumentRequestValidator()
        {
            //RuleFor(x => x.DocumentName).NotEmpty().MaximumLength(125);
        }
    }

    public sealed class UpdateJsonDocumentEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapPut("/api/jsonDocuments/{documentName}", HandleUpdateJsonDocument).WithTags("JsonDocuments")
                .WithName(nameof(UpdateJsonDocument))
                .WithSummary("Update JsonDocument");
                //.AddEndpointFilter<IdValidationFilter>()
                //.AddEndpointFilter<RequestValidationFilter<Request>>();
        }
    }

    public static async Task<Results<Ok<Response>, ProblemHttpResult>> HandleUpdateJsonDocument(string documentName, Request req, ISender sender)
    {
        var updateJsonDocumentCommand = req.ToUpdateJsonDocumentCommand(documentName);
        var result = await sender.Send(updateJsonDocumentCommand);
        return result.Match<Results<Ok<Response>, ProblemHttpResult>>(
            jsonDocument => TypedResults.Ok(jsonDocument.ToUpdateJsonDocumentResponse()), //return the updated jsonDocument
            errors => errors.ToProblemHttpResult()
        );
    }

}


