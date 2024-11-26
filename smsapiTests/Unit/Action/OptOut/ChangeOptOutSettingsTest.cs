using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.OptOut;

namespace smsapiTests.Unit.Action.OptOut;

[TestClass]
public class ChangeOptOutSettingsTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public ChangeOptOutSettingsTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void valid_uri()
    {
        CreateChangeOptOutSettings().Execute();

        _proxyAssert.AssertUriEquals("opt_outs/settings");
    }

    [TestMethod]
    public void request_is_empty_when_no_changes()
    {
        CreateChangeOptOutSettings().Execute();

        _proxyAssert.AssertNoParameters();
    }

    [TestMethod]
    public void request_contains_brand_name()
    {
        var brandName = "any brand name";

        CreateChangeOptOutSettings()
            .ChangeBrandName(brandName)
            .Execute();

        _proxyAssert.AssertParametersContain("brand", brandName);
    }

    [TestMethod]
    public void valid_method()
    {
        CreateChangeOptOutSettings().Execute();

        _proxyAssert.AssertRequestMethod(RequestMethod.PUT);
    }

    private ChangeOptOutSettings CreateChangeOptOutSettings()
    {
        var action = new ChangeOptOutSettings();
        action.Proxy(_spyProxy);

        return action;
    }
}
