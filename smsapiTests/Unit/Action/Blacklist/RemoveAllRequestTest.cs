using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action.Blacklist;

namespace smsapiTests.Unit.Action.Blacklist;

[TestClass]
public class RemoveAllRequestTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public RemoveAllRequestTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void uri_is_valid()
    {
        RemoveAll().Execute();
        
        _proxyAssert.AssertUriEquals("blacklist/phone_numbers");
    }
    
    [TestMethod]
    public void request_does_not_contain_body()
    {
        RemoveAll().Execute();
        
        _proxyAssert.AssertNoParameters();
    }

    private RemoveAll RemoveAll()
    {
        var action = new RemoveAll();
        action.Proxy(_spyProxy);

        return action;
    }
}
