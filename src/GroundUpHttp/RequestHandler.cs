using System.Text;

public class RequestHandler
{
    public RequestHandler(IEnumerable<Func<HttpContext, RequestDelegate, Task>> enumerable, Stream stream)
    {
        _middleware  = enumerable;
        _stream = stream;
        Context = new HttpContext();
    }

    public HttpContext Context {get;set;}

    public async Task HandleAsync()
    {
        // need to read first bit of stream to get header and such
        // need to pass body part of stream to COntext.Request.Body
        // need to flush stream so it can be written to, maybe it doesnt need to be flushed

        Console.WriteLine($"{DateTime.Now:yyyy:MM:dd HH:mm:ss:ff}");

        HttpRequestBuilder builder = new();

        int receivedBytes = 0;
        byte[] buffer = new byte[1024];
        int position = 0;
        do
        {
            receivedBytes = await _stream.ReadAsync(buffer);

            string requestString = Encoding.UTF8.GetString(buffer, position, receivedBytes);
            builder.Parse(requestString);

            if(receivedBytes < buffer.Length)
                break;
            position += receivedBytes;
        } while(receivedBytes > 0);

        Context.Request = builder.Build();

        await RunPipeline(_middleware.GetEnumerator());

        string content = "<html><head><title>Test</title></head><body><h1>HTML!!</h1></body></html>";
    
        StringBuilder sb = new();
        sb.AppendLine("HTTP/1,1 200 OK")
            .AppendLine("Date: 23 Jun 2026 06:40:00 GMT")
            .AppendLine("Server: GroundUpHttp")
            .AppendLine("Content-Type: text/html; charset=UTF-8")
            .AppendLine($"Content-Length: {content.Length}")
            .AppendLine("Connection: close")
            .AppendLine(string.Empty)
            .AppendLine(content);
        _stream.Write(Encoding.UTF8.GetBytes(sb.ToString()));
    }

    private Task RunPipeline(IEnumerator<Func<HttpContext, RequestDelegate, Task>> middlewareEnumerator)
    {
        if(!middlewareEnumerator.MoveNext())
            return Task.CompletedTask;
        return middlewareEnumerator.Current(Context, d => RunPipeline(middlewareEnumerator));
    }

    private readonly IEnumerable<Func<HttpContext, RequestDelegate, Task>> _middleware;
    private readonly Stream _stream;
}