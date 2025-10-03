using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.HLR;

[TestClass]
public class LookupResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void successfully_request_lookup()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            "[]".ToHttpEntityStreamTask(),
            HttpStatusCode.Accepted
        );

        Lookup().Execute();

        Assert.IsTrue(true);
    }

    private Lookup Lookup()
    {
        var action = new Lookup("48500500");
        action.Proxy(_proxyStub);

        return action;
    }
}
