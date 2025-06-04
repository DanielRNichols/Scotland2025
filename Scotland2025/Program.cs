using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Json;
using MudBlazor.Services;
using Scotland2025.Abstractions.Data;
using Scotland2025.Application;
using Scotland2025.Components;
using Scotland2025.Endpoints;
using Scotland2025.Infrastructure;
using Scotland2025.Services.Data;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add MudBlazor services
builder.Services.AddMudServices();


builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IDataService, DataService>();


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
    .AddInteractiveServerRenderMode();

app.MapApiEndpoints();

app.Run();
