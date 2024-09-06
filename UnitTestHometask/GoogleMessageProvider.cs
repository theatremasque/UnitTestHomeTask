namespace UnitTestHometask;

public class GoogleMessageProvider : IGoogleMessageProvider
{
    private const string Url = "https://google.com";
    
    private readonly HttpClient _client;

    public GoogleMessageProvider()
    {
        _client = new HttpClient();
    }

    public Task<HttpResponseMessage> SendAsync()
    {
        return _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, Url));
    }
}