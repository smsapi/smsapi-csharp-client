using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.OptOut;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.OptOut;

[TestClass]
public class OptOutSettingsResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void see_brand()
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

        var result = GetSettings().Execute();

        Assert.AreEqual(brand, result.Brand);
    }
    
    private GetOptOutSettings GetSettings()
    {
        var action = new GetOptOutSettings();
        action.Proxy(_proxyStub);

        return action;
    }
}
