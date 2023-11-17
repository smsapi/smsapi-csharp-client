using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action.MFA;

namespace smsapiTests.Unit.Action.MFA;

[TestClass]
public class VerifyMFACodeTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public VerifyMFACodeTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        VerifyMfaCodeAction(GetAnyPhoneNumber(), GetAnyVerificationCode()).Execute();
        
        Assert.AreEqual("mfa/codes/verifications", _spyProxy.RequestedUri);
    }
    
    [TestMethod]
    public void request_contains_phone_number_and_code()
    {
        var phoneNumber = GetAnyPhoneNumber();
        var code = GetAnyVerificationCode();

        VerifyMfaCodeAction(phoneNumber, code).Execute();
        
        _proxyAssert.AssertParametersContain("phone_number", phoneNumber);
        _proxyAssert.AssertParametersContain("code", code);
    }

    private static string GetAnyPhoneNumber() => "48500100100";
    private static string GetAnyVerificationCode() => "123456";

    private VerifyMFACode VerifyMfaCodeAction(string phoneNumber, string code)
    {
        var action = new VerifyMFACode(phoneNumber, code);
        action.Proxy(_spyProxy);

        return action;
    }
}
