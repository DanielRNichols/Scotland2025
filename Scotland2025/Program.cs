using MudBlazor.Services;
using Scotland2025.Abstractions.Data;
using Scotland2025.Application;
using Scotland2025.Abstractions.Versioning;
using Scotland2025.Components;
using Scotland2025.Services.Data;
using Scotland2025.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add MudBlazor services
builder.Services.AddMudServices();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<IJsonDocumentsDataService, JsonDocumentsDataService>();
builder.Services.AddScoped<IImagesDataService, ImagesDataService>();
builder.Services.AddScoped<IVersioningService, VersioningService>();


//builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);


var app = builder.Build();


app.MapDefaultEndpoints();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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


app.Run();
