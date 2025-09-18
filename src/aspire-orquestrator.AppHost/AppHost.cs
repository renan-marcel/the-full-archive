var builder = DistributedApplication.CreateBuilder(args);


// Builds the image from your Dockerfile and runs it as a service
var mySvc = builder.AddContainer("my-n8n", "renan/n8n-customn:latest")
    .WithDockerfile(
            "./Dockerfiles/n8n",           // docker build context
            "Dockerfile")      // Dockerfile path
    .WithHttpEndpoint(port: 5678, targetPort: 5678)                // exposes HTTP endpoint
    .WithEnvironment("N8N_PORT", "5678")
    .WithEnvironment("GENERIC_TIMEZONE", "America/Sao_Paulo")
    .WithEnvironment("N8N_ENCRYPTION_KEY", "your-very-secure-encryption-key-here-change-this-for-prod")
    .WithBindMount("../../data/n8n", "/home/node/.n8n"); // optional volume


builder.AddProject<Projects.the_full_archive_presentation_api>("the-full-archive-presentation-api");


await builder.Build().RunAsync();
