var builder = DistributedApplication.CreateBuilder(args);


var postgres = builder.AddPostgres("postgres");
var n8ndb = postgres.AddDatabase("n8n");

var pgadmin = postgres.WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050));

// Builds the image from your Dockerfile and runs it as a service
var my_n8n = builder.AddContainer("my-n8n", "renan/n8n-customn:latest")
    .WithDockerfile(
            "./Dockerfiles/n8n",           // docker build context
            "Dockerfile")      // Dockerfile path
    .WithHttpEndpoint(port: 5678, targetPort: 5678)                // exposes HTTP endpoint
    .WithEnvironment("N8N_PORT", "5678")
    .WithEnvironment("GENERIC_TIMEZONE", "America/Sao_Paulo")
    .WithEnvironment("N8N_ENCRYPTION_KEY", "your-very-secure-encryption-key-here-change-this-for-prod")
    .WithBindMount("../../data/n8n", "/home/node/.n8n")
    .WithReference(n8ndb)
    .WaitFor(n8ndb); // optional volume


var presentation_api = builder.AddProject<Projects.the_full_archive_presentation_api>("the-full-archive-presentation-api")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithEnvironment("N8N__BaseUrl", "http://my-n8n:5678");

await builder.Build().RunAsync();
