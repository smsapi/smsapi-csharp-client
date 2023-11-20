using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action.Blacklist;

namespace smsapiTests.Unit.Action.Blacklist;

[TestClass]
public class RemoveRequestTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public RemoveRequestTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void uri_contains_id()
    {
        var recordId = "5A5359173738303F2F95B7E2";
        
        Remove(recordId).Execute();
        
        _proxyAssert.AssertUriEquals($"blacklist/phone_numbers/{recordId}");
    }

    private Remove Remove(string id)
    {
        var action = new Remove(id);
        action.Proxy(_spyProxy);

        return action;
    }
}
