﻿using FluentValidation;

namespace Scotland2025.Filters;

public class RequestValidationFilter<T> : IEndpointFilter
{
    private readonly IValidator<T> _validator;

    public RequestValidationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.Arguments.OfType<T>().First();

        var result = await _validator.ValidateAsync(request, context.HttpContext.RequestAborted);
        if(!result.IsValid)
        {
            return TypedResults.ValidationProblem(result.ToDictionary());
        }

        return await next(context);
    }
}
