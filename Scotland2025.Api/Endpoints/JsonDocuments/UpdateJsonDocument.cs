using FluentValidation;
using Scotland2025.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Application.JsonDocuments;
using Scotland2025.Api.Filters;
using Scotland2025.Api.Endpoints;
using Scotland2025.Api.Endpoints.JsonDocuments;

namespace Scotland2025.Api.Endpoints.JsonDocuments;

public static class UpdateJsonDocument
{
    //public record Request(string JsonValue);

    //public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static UpdateJsonDocumentCommand ToUpdateJsonDocumentCommand(this Contracts.JsonDocuments.UpdateJsonDocument.Request req, string documentName)
    {
        return new UpdateJsonDocumentCommand(documentName, req.JsonValue);
    }
    public static Contracts.JsonDocuments.UpdateJsonDocument.Response ToUpdateJsonDocumentResponse(this JsonDocument result)
    {
        return new Contracts.JsonDocuments.UpdateJsonDocument.Response(result.Id, result.DocumentName, result.JsonValue, result.LastModified);
    }

    public class UpdateJsonDocumentRequestValidator : AbstractValidator<Contracts.JsonDocuments.UpdateJsonDocument.Request>
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

    public static async Task<Results<Ok<Contracts.JsonDocuments.UpdateJsonDocument.Response>, ProblemHttpResult>> HandleUpdateJsonDocument(string documentName, Contracts.JsonDocuments.UpdateJsonDocument.Request req, ISender sender)
    {
        var updateJsonDocumentCommand = req.ToUpdateJsonDocumentCommand(documentName);
        var result = await sender.Send(updateJsonDocumentCommand);
        return result.Match<Results<Ok<Contracts.JsonDocuments.UpdateJsonDocument.Response>, ProblemHttpResult>>(
            jsonDocument => TypedResults.Ok(jsonDocument.ToUpdateJsonDocumentResponse()), //return the updated jsonDocument
            errors => errors.ToProblemHttpResult()
        );
    }

}


