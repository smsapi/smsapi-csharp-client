using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.MFA;
using SMSApi.Api.Response.MFA.Exception;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.MFA;

[TestClass]
public class VerifyMFACodeResponseTest
{
    private readonly ProxyStub _proxyStub = new();
    
    [TestMethod]
    public void pass_when_code_is_valid()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            new Dictionary<string, dynamic>().ToHttpEntityStreamTask(),
            HttpStatusCode.NoContent
        );
        
        VerifyMfaCodeAction(GetAnyPhoneNumber(), GetAnyVerificationCode()).Execute();
        
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    public void throw_when_code_is_expired()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            new Dictionary<string, dynamic>().ToHttpEntityStreamTask(),
            HttpStatusCode.RequestTimeout
        );
        
        var action = () => VerifyMfaCodeAction(GetAnyPhoneNumber(), GetAnyVerificationCode()).Execute();

        Assert.ThrowsException<ExpiredVerificationCodeException>(action);
    }
    
    [TestMethod]
    public void throw_when_code_is_invalid()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            new Dictionary<string, dynamic>().ToHttpEntityStreamTask(),
            HttpStatusCode.NotFound
        );
        
        var action = () => VerifyMfaCodeAction(GetAnyPhoneNumber(), GetAnyVerificationCode()).Execute();

        Assert.ThrowsException<InvalidVerificationCodeException>(action);
    }
   
    private static string GetAnyPhoneNumber() => "48500100100";
    private static string GetAnyVerificationCode() => "123456";

    private VerifyMFACode VerifyMfaCodeAction(string phoneNumber, string code)
    {
        var action = new VerifyMFACode(phoneNumber, code);
        action.Proxy(_proxyStub);

        return action;
    }
}
