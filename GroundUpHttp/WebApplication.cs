using System.Net;
using System.Net.Sockets;

public class WebApplication
{

    public WebApplication()
    {
    }

    public WebApplication(int port)
    {
        _port = port;
    }

    public static WebApplicationBuilder CreateBuilder(string[] args) => new(args);


    public void Use(Func<HttpContext, RequestDelegate, Task> func) => _list.Add(func);

    public void Run()
    {
        TcpListener listener = new(IPAddress.Any, _port);
        listener.Start();
        while(true)
        {
            using TcpClient handler = listener.AcceptTcpClient();
            using NetworkStream stream = handler.GetStream();
            new RequestHandler(_list, stream).HandleAsync().GetAwaiter().GetResult();
        }
    }

    private readonly List<Func<HttpContext, RequestDelegate, Task>> _list = [];
    private readonly int _port = 80;
}

public delegate Task RequestDelegate(HttpContext context);
