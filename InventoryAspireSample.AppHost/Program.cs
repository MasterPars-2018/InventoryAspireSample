var builder = DistributedApplication.CreateBuilder(args);


var connectionString = builder.AddConnectionString("sql");





var api = builder.AddProject<Projects.InventoryAspireSample_API>(name: "api")
  .WithReference(connectionString);






builder.AddProject<Projects.InventoryAspireSample_WEB>(name: "frontend")
    .WithReference(api)
    .WaitFor(api)
    .WithExternalHttpEndpoints();



builder.Build().Run();
