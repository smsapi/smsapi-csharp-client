using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.OptOut;

namespace smsapiTests.Unit.Action.OptOut;

[TestClass]
public class OptOutSettingsTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public OptOutSettingsTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        CreateOptOutSettings().Execute();
        
        _proxyAssert.AssertUriEquals("opt_outs/settings");
    }
   
    [TestMethod]
    public void valid_method()
    {
        CreateOptOutSettings().Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }

    private GetOptOutSettings CreateOptOutSettings()
    {
        var action = new GetOptOutSettings();
        action.Proxy(_spyProxy);

        return action;
    }
}
