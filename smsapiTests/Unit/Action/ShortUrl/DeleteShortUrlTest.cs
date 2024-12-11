using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class DeleteShortUrlTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public DeleteShortUrlTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        var id = "1";

        DeleteShortUrl(id).Execute();
        
        _proxyAssert.AssertUriEquals($"short_url/links/{id}");
    }
    
    [TestMethod]
    public void send_delete_request()
    {
        DeleteShortUrl("any id").Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.DELETE);
    }

    private DeleteShortUrl DeleteShortUrl(string id)
    {
        var action = new DeleteShortUrl(id);
        action.Proxy(_spyProxy);

        return action;
    }
}
