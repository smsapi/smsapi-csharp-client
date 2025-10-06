using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Sendernames;

namespace smsapiTests.Unit.Action.Sendernames;

[TestClass]
public class CreateSendernameRequestTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public CreateSendernameRequestTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void uri_is_valid()
    {
        Create();
        
        _proxyAssert.AssertUriEquals("sms/sendernames");
    }

    [TestMethod]
    public void request_method_is_post()
    {
        Create();

        _proxyAssert.AssertRequestMethod(RequestMethod.POST);
    }
    
    [TestMethod]
    public void request_contains_sender()
    {
        var sender = "any sender";
        
        Create(sender);

        _proxyAssert.AssertParametersContain("sender", sender);
    }

    private void Create(string? sender = null)
    {
        var action = new CreateSendername(sender ?? "any");
        action.Proxy(_spyProxy);
        action.Execute();
    }
}
