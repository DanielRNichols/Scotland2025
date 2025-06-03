using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Scotland2025.UI;
using MudBlazor.Services;
using Scotland2025.UI.Abstractions.Data;
using Scotland2025.UI.Abstractions.Versioning;
using Scotland2025.UI.Services.Versioning;
using Scotland2025.UI.Services.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7243/api/") });

builder.Services.AddScoped<IJsonDocumentService, JsonDocumentService>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IVersioningService, VersioningService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
