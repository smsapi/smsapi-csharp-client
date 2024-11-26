using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.OptOut;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.OptOut;

[TestClass]
public class ChangeOptOutSettingsResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void see_brand_after_update()
    {
        var brand = "any brand";

        var response = new Dictionary<string, dynamic>
        {
            { "brand", brand }
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = CreateChangeOptOutSettings()
            .ChangeBrandName(brand)
            .Execute();

        Assert.AreEqual(brand, result.Brand);
    }
    
    private ChangeOptOutSettings CreateChangeOptOutSettings()
    {
        var action = new ChangeOptOutSettings();
        action.Proxy(_proxyStub);

        return action;
    }
}
