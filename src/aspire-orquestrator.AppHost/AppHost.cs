using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);


builder.AddProject<Projects.the_full_archive_presentation_api>("the-full-archive-presentation-api");


await builder.Build().RunAsync();
