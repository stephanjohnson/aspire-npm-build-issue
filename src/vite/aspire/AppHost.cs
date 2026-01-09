var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.webapi>("webapi");

var versionParameter = builder.AddParameter("VERSION", "development", secret: false);

var app = builder.AddViteApp("app", "../app")
    .WithReference(api)
    .WaitFor(api)
    .WithEnvironment("NUXT_PUBLIC_VERSION", versionParameter)
    .PublishAsDockerFile()
    .WithExternalHttpEndpoints();

builder.Build().Run();
