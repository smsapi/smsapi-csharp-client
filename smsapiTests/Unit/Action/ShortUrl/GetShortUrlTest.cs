using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class GetShortUrlTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public GetShortUrlTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        var id = "1";

        GetShortUrl(id).Execute();
        
        _proxyAssert.AssertUriEquals($"short_url/links/{id}");
    }
    
    [TestMethod]
    public void send_get_request()
    {
        GetShortUrl("any id").Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }
    private GetShortUrl GetShortUrl(string id)
    {
        var action = new GetShortUrl(id);
        action.Proxy(_spyProxy);

        return action;
    }
}
