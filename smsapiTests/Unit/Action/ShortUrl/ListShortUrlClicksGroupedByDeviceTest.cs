using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class ListShortUrlClicksGroupedByDeviceTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public ListShortUrlClicksGroupedByDeviceTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void add_ids_to_query()
    {
        var ids = new[] {"1", "2"};

        CreateShortUrGroupedByDevice(ids).Execute();

        _proxyAssert.AssertUriEquals("short_url/clicks_by_mobile_device?links%5b%5d=1&links%5b%5d=2");
    }
    
    [TestMethod]
    public void valid_method()
    {
        CreateShortUrGroupedByDevice("any").Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }

    [TestMethod]
    public void require_at_least_1_id()
    {
        var action = () => CreateShortUrGroupedByDevice().Execute();

        var exception = Assert.ThrowsException<ArgumentException>(action);
        Assert.AreEqual("Invalid ids count, at least one is required.", exception.Message);
    }

    private ListShortUrlClicksGroupedByDevice CreateShortUrGroupedByDevice(params string[] ids)
    {
        var action = new ListShortUrlClicksGroupedByDevice(ids);
        action.Proxy(_spyProxy);

        return action;
    }
}
