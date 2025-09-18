using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);


var file = new FileInfo(@"..\..\dockerfiles\n8n\Dockerfile");

var apiService = builder.AddProject<Projects.aspire_orquestrator_ApiService>("apiservice")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health");

var n8nService = builder.AddDockerfile("n8n", file.FullName)
    .WithEndpoint(port: 5678, isExternal: true, targetPort: 5678)
    .WithVolume("../../data/n8n", "/home/node/.n8n");

await builder.Build().RunAsync();
