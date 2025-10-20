using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Sendernames;

namespace smsapiTests.Unit.Action.Sendernames;

[TestClass]
public class DeleteSendernameRequestTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public DeleteSendernameRequestTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void uri_is_valid()
    {
        var sender = "any sender";

        Delete(sender);

        var encodedSender = Uri.EscapeDataString(sender);
        _proxyAssert.AssertUriEquals($"sms/sendernames/{encodedSender}");
    }

    [TestMethod]
    public void request_method_is_delete()
    {
        Delete();

        _proxyAssert.AssertRequestMethod(RequestMethod.DELETE);
    }

    private void Delete(string? sender = null)
    {
        var action = new DeleteSendername(sender ?? "any");
        action.Proxy(_spyProxy);
        action.Execute();
    }
}
