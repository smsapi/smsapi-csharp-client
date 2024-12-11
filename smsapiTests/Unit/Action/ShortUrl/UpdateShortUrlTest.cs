using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class UpdateShortUrlTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public UpdateShortUrlTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        var id = "1";

        UpdateShortUrl(id).Execute();
        
        _proxyAssert.AssertUriEquals($"short_url/links/{id}");
    }
    
    [TestMethod]
    public void send_put_request()
    {
        UpdateShortUrl("any id").Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.PUT);
    }

    [TestMethod]
    public void not_parameters_when_no_changes()
    {
        UpdateShortUrl("any id").Execute();

        _proxyAssert.AssertParametersCount(0);
    }

    [TestMethod]
    public void change_url()
    {
        var newUrl = "http://example.com";

        UpdateShortUrl("any id")
            .ChangeUrl(newUrl)
            .Execute();

        _proxyAssert.AssertParametersCount(1);
        _proxyAssert.AssertParametersContain("url", newUrl);
    }

    [TestMethod]
    public void change_name()
    {
        var newName = "newLinkName";

        UpdateShortUrl("any id")
            .ChangeName(newName)
            .Execute();

        _proxyAssert.AssertParametersCount(1);
        _proxyAssert.AssertParametersContain("name", newName);
    }

    [TestMethod]
    public void change_description()
    {
        var newDescription = "new description";

        UpdateShortUrl("any id")
            .ChangeDescription(newDescription)
            .Execute();

        _proxyAssert.AssertParametersCount(1);
        _proxyAssert.AssertParametersContain("description", newDescription);
    }

    private UpdateShortUrl UpdateShortUrl(string id)
    {
        var action = new UpdateShortUrl(id);
        action.Proxy(_spyProxy);

        return action;
    }
}
