WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// builder.Services;
// builder.Configuration;
// builder.Logging;
// builder.WebHost;
// builder.Host;
// builder.Metrics;

WebApplication app = builder.Build();

app.UseLogging();

app.Run();