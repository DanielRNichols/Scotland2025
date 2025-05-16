var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Scotland2025>("scotland2025");

builder.Build().Run();
