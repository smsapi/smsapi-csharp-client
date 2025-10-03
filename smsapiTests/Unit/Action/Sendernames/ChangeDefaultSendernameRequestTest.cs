using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Sendernames;

namespace smsapiTests.Unit.Action.Sendernames;

[TestClass]
public class ChangeDefaultSendernameRequestTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public ChangeDefaultSendernameRequestTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void uri_is_valid()
    {
        var sender = "any sender";

        Change(sender);

        var encodedSender = Uri.EscapeDataString(sender);
        _proxyAssert.AssertUriEquals($"sms/sendernames/{encodedSender}/commands/make_default");
    }

    [TestMethod]
    public void request_method_is_post()
    {
        Change();

        _proxyAssert.AssertRequestMethod(RequestMethod.POST);
    }

    private void Change(string? sender = null)
    {
        var action = new ChangeDefaultSendername(sender ?? "any");
        action.Proxy(_spyProxy);
        action.Execute();
    }
}
