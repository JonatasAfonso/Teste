var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Recrutamento_Web>("web");

builder.Build().Run();
