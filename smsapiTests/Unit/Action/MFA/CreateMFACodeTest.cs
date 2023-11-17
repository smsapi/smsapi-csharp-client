using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action.MFA;

namespace smsapiTests.Unit.Action.MFA;

[TestClass]
public class CreateMFACodeTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public CreateMFACodeTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        var phoneNumber = GetAnyPhoneNumber();

        CreateMfaCodeAction(phoneNumber).Execute();
        
        Assert.AreEqual("mfa/codes", _spyProxy.RequestedUri);
    }
    
    [TestMethod]
    public void request_contains_only_phone_number()
    {
        var phoneNumber = GetAnyPhoneNumber();

        CreateMfaCodeAction(phoneNumber).Execute();
        
        _proxyAssert.AssertParametersContain("phone_number", phoneNumber);
        _proxyAssert.AssertParametersDoesNotContain("content");
        _proxyAssert.AssertParametersDoesNotContain("fast");
        _proxyAssert.AssertParametersDoesNotContain("from");
    }
    
    [TestMethod]
    public void create_as_fast()
    {
        var create = CreateMfaCodeAction(GetAnyPhoneNumber())
            .AsFast();

        create.Execute();
        
        _proxyAssert.AssertParametersContain("fast", "1");
    }
    
    [TestMethod]
    public void create_with_content()
    {
        var content = "any content";
        var create = CreateMfaCodeAction(GetAnyPhoneNumber())
            .WithContent(content);

        create.Execute();
        
        _proxyAssert.AssertParametersContain("content", content);
    }
    
    [TestMethod]
    public void create_with_sendername()
    {
        var sendername = "abc";
        var create = CreateMfaCodeAction(GetAnyPhoneNumber())
            .FromSendername(sendername);

        create.Execute();
        
        _proxyAssert.AssertParametersContain("from", sendername);
    }

    private static string GetAnyPhoneNumber() => "48500100100";

    private CreateMFACode CreateMfaCodeAction(string phoneNumber)
    {
        var action = new CreateMFACode(phoneNumber);
        action.Proxy(_spyProxy);

        return action;
    }
}
