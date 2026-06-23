public class HttpContext
{
    public HttpRequest Request {get;set;}
    public HttpResponse Response {get;set;}
}

public class HttpRequest
{
    public HttpRequest(string method, string target, string protocol, Dictionary<string, string> headers)
    {
        Method = method;
        Target = target;
        Protocol = protocol;
        Headers = headers;
    }

    public string Method {get;}
    public string Target {get;}
    public string Protocol {get;}
    public Dictionary<string, string> Headers {get;}
    public Stream? Body {get;set;}
}

public class HttpResponse
{
    public Stream? Body {get;set;}
    public string ContentType {get;set;} = "text/html";
    public int Status {get;set;} = 200;
}

internal sealed class HttpRequestBuilder
{
    public void Parse(string line) => _lines.Add(line);

    public HttpRequest Build()
    {
        string requestLine = _lines[0];
        string[] requestLineParts = requestLine.Split(' ');

        Dictionary<string, string> headers = [];

        int i = 1;
        string line = string.Empty;
        do
        {
            line = _lines[i];
            string[] splitLine = line.Split(' ');
            string key = splitLine[0];
            if(string.IsNullOrWhiteSpace(key))
                continue;
            headers[key] = splitLine[1];
        } while (line != string.Empty);

        return new HttpRequest(requestLineParts[0], requestLineParts[1], requestLineParts[2], headers);
    }

    private readonly List<string> _lines = [];
}