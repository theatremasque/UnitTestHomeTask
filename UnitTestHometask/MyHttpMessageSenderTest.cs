using System.Net;
using System.Net.Http.Headers;
using Moq;

namespace UnitTestHometask;

public class MyHttpMessageSenderTest
{
    private MyHttpMessageSender _sender;

    [SetUp]
    public void Initialize()
    {
        var mockProvider = new Mock<IGoogleMessageProvider>();

        mockProvider.Setup(s => s.SendAsync())
            .ReturnsAsync(new HttpResponseMessage()
            {
                Content = new MultipartContent()
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("text/html")
                    }
                }
            });
        
        _sender = new MyHttpMessageSender(mockProvider.Object);
    }

    [TestCase(TestName = "Contains Content-Type header")]
    public async Task CallAsyncTest_ContentType_ReturnHeader()
    {
        // Arrange
        var exceptedContentTypeHeaders = new (string Key, IEnumerable<string> Value)[] 
            { ("Content-Type", new [] { "text/html" }) };

        // Act
        var actualContentTypeHeaders  = await _sender.CallAsync();

        var filteredContentTypeHeaders = actualContentTypeHeaders
            .Where(c => c.Key.Equals("Content-Type"));
        
        // Assert
        Assert.That(filteredContentTypeHeaders, Is.EqualTo(exceptedContentTypeHeaders));
    }
}