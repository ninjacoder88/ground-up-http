namespace GroundUpHttp.WebApp;

public static class LoggingMiddleware
{
    public static void UseLogging(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            // request
            IRequestHandler? requestHandler = context.Request.Services.GetService<IRequestHandler>();

            await next(context);

            // response
        });
    }
}