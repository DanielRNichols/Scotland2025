using Microsoft.AspNetCore.Http.HttpResults;
using Scotland2025.Client.Pages;
using Scotland2025.Components;
using Scotland2025.Application;
using Scotland2025.Infrastructure;
using Scotland2025.Endpoints;
using FluentValidation;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddApiEndpoints();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddOpenApi();


var app = builder.Build();

app.MapGet("/api/test", () =>
{
    return Results.Ok("Scotland 2025!");
});



app.MapDefaultEndpoints();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.MapOpenApi();
    //app.MapScalarApiReference(_ => _.Servers = []); // _ => _.Servers = [] is a workaround for a bug in Scalar.AspNetCore
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Scotland2025.Client._Imports).Assembly);

app.MapApiEndpoints();

app.Run();
