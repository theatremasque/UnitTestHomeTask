using System.Net;

namespace UnitTestHometask;

public class MyHttpMessageSenderTest
{
    private MyHttpMessageSender _sender;

    [SetUp]
    public void Initialize()
    {
        // very bad code))) but it test, and it`s okay to hard it))
        _sender = new MyHttpMessageSender(new GoogleMessageProvider(new HttpClient()));
    }

    [TestCase(TestName = "Contains Content-Type header")]
    public async Task CallAsyncTest_ContentType_ReturnHeader()
    {
        // Arrange
        var exceptedContentTypeHeaders = new (string Key, IEnumerable<string> Value)[] { ("Content-Type", new [] { "text/html; charset=ISO-8859-1" }) };

        // Act
        var actualContentTypeHeaders  = await _sender.CallAsync();

        var filteredContentTypeHeaders = actualContentTypeHeaders.Where(c => c.Key.Equals("Content-Type"));
        
        // Assert
        Assert.That(filteredContentTypeHeaders, Is.EqualTo(exceptedContentTypeHeaders));
    }
}