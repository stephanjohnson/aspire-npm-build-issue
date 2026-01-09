var builder = DistributedApplication.CreateBuilder(args);

var app = builder.AddViteApp("app", "../app")
    .WithWorkingDirectory("../app")
    .PublishAsDockerFile()
    .WithExternalHttpEndpoints();

builder.Build().Run();
