using GroundUpHttp.Interfaces;
using GroundUpHttp.Internal;

namespace GroundUpHttp;

public class WebApplicationBuilder
{
    public WebApplicationBuilder(string[] args)
    {
        _args = args;
        Services = new InternalServiceCollection();
        Configuration = new WebApplicationConfiguration();
    }

    public IConfiguration Configuration {get;}

    public IServiceCollection Services {get;}

    public WebApplication Build()
    {
        return new WebApplication();
    }

    private readonly string[] _args;
}