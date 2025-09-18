using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Parameters for Postgres credentials
var pgUser = builder.AddParameter("postgres-user");
var pgPassword = builder.AddParameter("postgres-password", secret: true);

var postgres = builder
    .AddPostgres("postgres")
    // Set Postgres container credentials from parameters
    .WithEnvironment("POSTGRES_USER", pgUser)
    .WithEnvironment("POSTGRES_PASSWORD", pgPassword)
    // Persist Postgres data to host folder
    .WithDataBindMount("../../data/postgres")
    .WithLifetime(ContainerLifetime.Persistent);

var n8ndb = postgres.AddDatabase("n8n");

var pgadmin = postgres.WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050));

// Builds the image from your Dockerfile and runs it as a service
var my_n8n = builder.AddContainer("my-n8n", "renan/n8n-customn:latest")
    .WithDockerfile(
            "./Dockerfiles/n8n",           // docker build context
            "Dockerfile")      // Dockerfile path
    .WithHttpEndpoint(port: 5678, targetPort: 5678) // exposes HTTP endpoint
                                                    // n8n → Postgres configuration
    .WithEnvironment("DB_TYPE", "postgresdb")
    .WithEnvironment("DB_POSTGRESDB_HOST", "postgres")   // service name in the Aspire network
    .WithEnvironment("DB_POSTGRESDB_PORT", "5432")
    .WithEnvironment("DB_POSTGRESDB_DATABASE", "n8n")
    .WithEnvironment("DB_POSTGRESDB_USER", pgUser)
    .WithEnvironment("DB_POSTGRESDB_PASSWORD", pgPassword)
    // Optional: default schema
    .WithEnvironment("DB_POSTGRESDB_SCHEMA", "public")
    // existing n8n settings
    .WithEnvironment("N8N_PORT", "5678")
    .WithEnvironment("GENERIC_TIMEZONE", "America/Sao_Paulo")
    .WithEnvironment("N8N_ENCRYPTION_KEY", "your-very-secure-encryption-key-here-change-this-for-prod")
    .WithBindMount("../../data/n8n", "/home/node/.n8n")
    .WithReference(n8ndb)
    .WaitFor(n8ndb)
    .WithLifetime(ContainerLifetime.Persistent);


var presentation_api = builder.AddProject<Projects.the_full_archive_presentation_api>("the-full-archive-presentation-api")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithEnvironment("N8N__BaseUrl", "http://my-n8n:5678");

await builder.Build().RunAsync();
