using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Sendernames;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Sendernames;

[TestClass]
public class ChangeDefaultSendernameResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void successfully_change_default_sendername()
    {
        var sender = "any sender";
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            "".ToHttpEntityStreamTask(),
            HttpStatusCode.NoContent
        );

        Change(sender);

        Assert.IsTrue(true);
    }

    private void Change(string? sender = null)
    {
        var action = new ChangeDefaultSendername(sender ?? "any");
        action.Proxy(_proxyStub);
        action.Execute();
    }
}
