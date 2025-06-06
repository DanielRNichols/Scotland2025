using FluentValidation;
using Scotland2025.Api.Endpoints;
using Scotland2025.Api.Extensions;
using Scotland2025.Application;
using Scotland2025.Infrastructure;


var AllowAllOrigins = "_allowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllOrigins,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddGlobalErrorHandling();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApiEndpoints();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.ApplyMigrations();
    app.MapOpenApi();

    //app.MapScalarApiReference(_ => _.Servers = []); // _ => _.Servers = [] is a workaround for a bug in Scalar.AspNetCore
}

app.UseGlobalErrorHandling();
app.UseHttpsRedirection();

app.UseCors(AllowAllOrigins);

app.MapGet("/api/test", () =>
{
    return Results.Ok("Scotland 2025!!!");
});

app.MapApiEndpoints();


app.Run();


