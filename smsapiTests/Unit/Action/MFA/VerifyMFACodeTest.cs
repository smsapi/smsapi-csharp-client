using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action.MFA;

namespace smsapiTests.Unit.Action.MFA;

[TestClass]
public class VerifyMFACodeTest
{
    private readonly SpyProxy _spyProxy = new();
    
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
        
        AssertParametersContain("phone_number", phoneNumber);
        AssertParametersContain("code", code);
    }

    private static string GetAnyPhoneNumber() => "48500100100";
    private static string GetAnyVerificationCode() => "123456";

    private VerifyMFACode VerifyMfaCodeAction(string phoneNumber, string code)
    {
        var action = new VerifyMFACode(phoneNumber, code);
        action.Proxy(_spyProxy);

        return action;
    }
    
    private void AssertParametersContain(string name, string value)
    {
        var expectedParameter = new KeyValuePair<string, string>(name, value);

        Assert.IsTrue(
            _spyProxy.Parameters.Contains(expectedParameter),
            $"Expected {value}, actual value: {_spyProxy.Parameters[name]}"
        );
    }
}
