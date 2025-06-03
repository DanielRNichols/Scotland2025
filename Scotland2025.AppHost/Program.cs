var builder = DistributedApplication.CreateBuilder(args);

var serverApp = builder.AddProject<Projects.Scotland2025>("scotland2025-server");

var api = builder.AddProject<Projects.Scotland2025_Api>("scotland2025-api");

builder.AddProject<Projects.Scotland2025_UI>("scotland2025-ui")
    .WaitFor(api);


builder.Build().Run();
