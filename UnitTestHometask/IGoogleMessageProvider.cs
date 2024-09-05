namespace UnitTestHometask;

public interface IGoogleMessageProvider
{
    public Task<HttpResponseMessage> SendAsync();
}