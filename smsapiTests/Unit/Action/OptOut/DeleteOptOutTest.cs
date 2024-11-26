using System;
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
        var optOutId = Guid.NewGuid();

        CreateOptOutDelete(optOutId).Execute();
        
        _proxyAssert.AssertUriEquals($"opt_outs/{optOutId}");
    }
    
    [TestMethod]
    public void valid_method()
    {
        CreateOptOutDelete(Guid.NewGuid()).Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.DELETE);
    }

    private DeleteOptOut CreateOptOutDelete(Guid optOutId)
    {
        var action = new DeleteOptOut(optOutId);
        action.Proxy(_spyProxy);

        return action;
    }
}
