var builder = DistributedApplication.CreateBuilder(args);

var app = builder.AddProject<Projects.Scotland2025>("scotland2025");

var api = builder.AddProject<Projects.Scotland2025_Api>("scotland2025-api");

var poster = builder.AddProject<Projects.Scotland2025_JsonDocumentPoster>("scotland2025-jsondocumentposter")
    .WithExplicitStart();

builder.Build().Run();
