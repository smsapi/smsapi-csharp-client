using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Sendernames;

namespace smsapiTests.Unit.Action.Sendernames;

[TestClass]
public class GetSendernameRequestTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public GetSendernameRequestTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void uri_is_valid()
    {
        var sender = "any sender";

        Get(sender);

        var encodedSender = Uri.EscapeDataString(sender);
        _proxyAssert.AssertUriEquals($"sms/sendernames/{encodedSender}");
    }

    [TestMethod]
    public void request_method_is_get()
    {
        Get();

        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }

    private void Get(string? sender = null)
    {
        var action = new GetSendername(sender ?? "any");
        action.Proxy(_spyProxy);
        action.Execute();
    }
}
