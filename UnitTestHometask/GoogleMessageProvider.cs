namespace UnitTestHometask;

public class GoogleMessageProvider : IGoogleMessageProvider
{
    private const string Url = "https://google.com";
    
    private readonly HttpClient _client;

    public GoogleMessageProvider(HttpClient client)
    {
        _client = client;
    }

    public Task<HttpResponseMessage> SendAsync()
    {
        return _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, Url));
    }
}