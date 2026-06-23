// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

WebApplication app = WebApplicationBuilder.Build();

app.UseLogging();

app.Use(async (context, next) =>
{
    await next(context);
});

app.Run();