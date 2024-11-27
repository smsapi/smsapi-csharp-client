using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.OptOut;

namespace smsapiTests.Unit.Action.OptOut;

[TestClass]
public class DeleteOptOutTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public DeleteOptOutTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        var optOutId = AnyId();

        CreateOptOutDelete(optOutId).Execute();
        
        _proxyAssert.AssertUriEquals($"opt_outs/{optOutId}");
    }
    
    [TestMethod]
    public void valid_method()
    {
        CreateOptOutDelete(AnyId()).Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.DELETE);
    }

    private DeleteOptOut CreateOptOutDelete(string optOutId)
    {
        var action = new DeleteOptOut(optOutId);
        action.Proxy(_spyProxy);

        return action;
    }

    private static string AnyId() => "5A5359173738303F2F95B7E2";
}
