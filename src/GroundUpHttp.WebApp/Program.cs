using GroundUpHttp;
using GroundUpHttp.WebApp;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// builder.Configuration;
// builder.Logging;
// builder.WebHost;
// builder.Host;
// builder.Metrics;
builder.Services.AddScoped<IRequestHandler, RequestHandler>();

WebApplication app = builder.Build();

app.UseLogging();
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

app.Run();