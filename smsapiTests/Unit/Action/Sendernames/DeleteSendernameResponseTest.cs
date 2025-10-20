using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Sendernames;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Sendernames;

[TestClass]
public class DeleteSendernameResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void smoke_delete()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            "".ToHttpEntityStreamTask(),
            HttpStatusCode.Created
        );

        Delete();

        Assert.IsTrue(true);
    }

    private void Delete()
    {
        var action = new DeleteSendername("any");
        action.Proxy(_proxyStub);

        action.Execute();
    }
}
