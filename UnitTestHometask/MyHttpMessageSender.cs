namespace UnitTestHometask;

public class MyHttpMessageSender
{
    private readonly IGoogleMessageProvider _provider;

    public MyHttpMessageSender(IGoogleMessageProvider provider)
    {
        _provider = provider;
    }

    public async Task<IEnumerable<(string Key, IEnumerable<string> Value)>> CallAsync()
    {
        // status code is not success or is success
        var response = await _provider.SendAsync();

        return response.Content.Headers.Select(r => (r.Key, r.Value));
    }
}