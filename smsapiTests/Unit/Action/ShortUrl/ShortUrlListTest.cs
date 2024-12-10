using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class ShortUrlListTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public ShortUrlListTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        CreateShortUrlList().Execute();
        
        _proxyAssert.AssertUriEquals("short_url/links");
    }
    
    [TestMethod]
    public void valid_method()
    {
        CreateShortUrlList().Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }

    private ShortUrlList CreateShortUrlList()
    {
        var action = new ShortUrlList();
        action.Proxy(_spyProxy);

        return action;
    }
}
