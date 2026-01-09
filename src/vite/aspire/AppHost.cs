var builder = DistributedApplication.CreateBuilder(args);

var versionParameter = builder.AddParameter("VERSION", "development", secret: false);

var app = builder.AddViteApp("app", "../app")
    .WithEnvironment("NUXT_PUBLIC_VERSION", versionParameter)
    .PublishAsDockerFile()
    .WithExternalHttpEndpoints();

builder.Build().Run();
