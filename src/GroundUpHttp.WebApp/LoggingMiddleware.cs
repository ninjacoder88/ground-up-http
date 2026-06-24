namespace GroundUpHttp.WebApp;

public static class LoggingMiddleware
{
    public static void UseLogging(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            // request

            await next(context);

            // response
        });
    }
}