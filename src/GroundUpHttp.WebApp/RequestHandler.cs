using System.Threading.Tasks;

namespace GroundUpHttp.WebApp;

public interface IRequestHandler
{
    Task HandleAsync();
}

public sealed class RequestHandler : IRequestHandler
{
    public async Task HandleAsync()
    {
        await Task.Delay(100);
        return;
    }
}