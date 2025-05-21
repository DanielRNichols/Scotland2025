var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Scotland2025_Api>("scotland2025-api");

builder.Build().Run();
