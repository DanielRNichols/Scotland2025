using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Api.Extensions;
using Scotland2025.Application.Images;

namespace Scotland2025.Api.Endpoints.Images;

public static class UpdateImage
{
    //public record Request(string JsonValue);

    //public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);

    public static UpdateImageCommand ToUpdateImageCommand(this Contracts.Images.UpdateImage.Request req, int id)
    {
        return new UpdateImageCommand(id, req.Url, req.Description, req.DateAdded, req.AddedBy);
    }
    public static Contracts.Images.UpdateImage.Response ToUpdateImageResponse(this Image result)
    {
        return new Contracts.Images.UpdateImage.Response(result.Id, result.Url, result.Description, result.DateAdded, result.AddedBy);
    }

    public class UpdateImageRequestValidator : AbstractValidator<Contracts.Images.UpdateImage.Request>
    {
        public UpdateImageRequestValidator()
        {
            //RuleFor(x => x.DocumentName).NotEmpty().MaximumLength(125);
        }
    }

    public sealed class UpdateImageEndpoint() : IApiEndpoint
    {
        public void MapApiEndpoint(IEndpointRouteBuilder routes)
        {
            routes.MapPut("/api/images/{id}", HandleUpdateImage).WithTags("Images")
                .WithName(nameof(UpdateImage))
                .WithSummary("Update Image");
                //.AddEndpointFilter<IdValidationFilter>()
                //.AddEndpointFilter<RequestValidationFilter<Request>>();
        }
    }

    public static async Task<Results<Ok<Contracts.Images.UpdateImage.Response>, ProblemHttpResult>> HandleUpdateImage(int id, Contracts.Images.UpdateImage.Request req, ISender sender)
    {
        var updateImageCommand = req.ToUpdateImageCommand(id);
        var result = await sender.Send(updateImageCommand);
        return result.Match<Results<Ok<Contracts.Images.UpdateImage.Response>, ProblemHttpResult>>(
            image => TypedResults.Ok(image.ToUpdateImageResponse()), //return the updated image
            errors => errors.ToProblemHttpResult()
        );
    }

}


