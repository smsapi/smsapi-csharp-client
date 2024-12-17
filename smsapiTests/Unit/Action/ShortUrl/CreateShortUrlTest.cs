using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class CreateShortUrlTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public CreateShortUrlTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        CreateShortUrl().Execute();
        
        _proxyAssert.AssertUriEquals("short_url/links");
    }
    
    [TestMethod]
    public void send_post_request()
    {
        CreateShortUrl().Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.POST);
    }

    [TestMethod]
    public void send_name_and_url()
    {
        var name = "any name";
        var url = "http://example.com";

        CreateShortUrl(name, url).Execute();

        _proxyAssert.AssertParametersCount(2);
        _proxyAssert.AssertParametersContain("name", name);
        _proxyAssert.AssertParametersContain("url", url);
    }

    [TestMethod]
    public void send_description()
    {
        var description = "any description";

        CreateShortUrl()
            .WithDescription(description)
            .Execute();

        _proxyAssert.AssertParametersCount(3);//obligatory name and url
        _proxyAssert.AssertParametersContain("description", description);
    }

    [TestMethod]
    public void send_name_and_file()
    {
        var name = "fancy name";
        var file = new MemoryStream();

        CreateShortUrl(name, file).Execute();

        _proxyAssert.AssertParametersCount(2);
        _proxyAssert.AssertParametersContain("name", name);
        _proxyAssert.AssertParametersContain("type", "FILE");
        _proxyAssert.AssertFileAttached(file);
    }

    [TestMethod]
    [DataRow(1, SMSApi.Api.Action.ShortUrl.CreateShortUrl.ShortUrlExpirationUnit.Days, "days")]
    [DataRow(2, SMSApi.Api.Action.ShortUrl.CreateShortUrl.ShortUrlExpirationUnit.Hours, "hours")]
    [DataRow(300, SMSApi.Api.Action.ShortUrl.CreateShortUrl.ShortUrlExpirationUnit.Minutes, "minutes")]
    [DataRow(60000, SMSApi.Api.Action.ShortUrl.CreateShortUrl.ShortUrlExpirationUnit.Seconds, "seconds")]
    public void send_expiration(int expirationTime, CreateShortUrl.ShortUrlExpirationUnit expirationUnit, string expectedExpirationUnit)
    {
        CreateShortUrl("any name", "http://example.com")
            .WithExpiration((uint)expirationTime, expirationUnit)
            .Execute();

        _proxyAssert.AssertParametersCount(4);//obligatory name and url
        _proxyAssert.AssertParametersContain("expire_time", expirationTime);
        _proxyAssert.AssertParametersContain("expire_unit", expectedExpirationUnit);
    }

    private CreateShortUrl CreateShortUrl(string name, string uri)
    {
        var action = new CreateShortUrl(name, uri);
        action.Proxy(_spyProxy);

        return action;
    }

    private CreateShortUrl CreateShortUrl(string name, Stream file)
    {
        var action = new CreateShortUrl(name, file);
        action.Proxy(_spyProxy);

        return action;
    }

    private CreateShortUrl CreateShortUrl()
    {
        var action = new CreateShortUrl("any", "any");
        action.Proxy(_spyProxy);

        return action;
    }
}
