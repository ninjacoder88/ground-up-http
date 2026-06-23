public class WebApplication
{

    public WebApplication Use(Func<HttpContext, RequestDelegate, Task> func)
    {
        return this;
    }

    public void Run()
    {
        
    }
}

public delegate Task RequestDelegate(HttpContext context);
