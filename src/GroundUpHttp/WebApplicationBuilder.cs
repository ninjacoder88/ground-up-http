public class WebApplicationBuilder
{
    public WebApplicationBuilder(string[] args)
    {
        _args = args;
    }

    public WebApplication Build()
    {
        return new WebApplication();
    }

    private readonly string[] _args;
}