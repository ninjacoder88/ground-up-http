namespace GroundUpHttp;

public class HttpResponse
{
    public Stream? Body {get;set;}
    public string ContentType {get;set;} = "text/html";
    public int Status {get;set;} = 200;
}