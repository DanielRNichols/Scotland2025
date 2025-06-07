var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Scotland2025>("scotland2025");

builder.AddProject<Projects.Scotland2025_Api>("scotland2025-api");

builder.AddProject<Projects.Scotland2025_JsonDocumentPoster>("scotland2025-jsondocumentposter");

builder.Build().Run();
