using GroundUpHttp.Interfaces;
using GroundUpHttp.Internal;

namespace GroundUpHttp;

public class HttpRequest
{
    public HttpRequest(string method, string target, string protocol, Dictionary<string, string> headers)
    {
        Method = method;
        Target = target;
        Protocol = protocol;
        Headers = headers;
        Services = new InternalServiceCollection();
    }

    public string Method {get;}
    public string Target {get;}
    public string Protocol {get;}
    public Dictionary<string, string> Headers {get;}
    public Stream? Body {get;set;}
    public IServiceCollection Services {get;}
}