using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action.MFA;

namespace smsapiTests.Unit.Action.MFA;

[TestClass]
public class CreateMFACodeTest
{
    private readonly SpyProxy _spyProxy = new();
    
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
        
        AssertParametersContain("phone_number", phoneNumber);
        AssertParametersDoesNotContain("content");
        AssertParametersDoesNotContain("fast");
        AssertParametersDoesNotContain("from");
    }
    
    [TestMethod]
    public void create_as_fast()
    {
        var create = CreateMfaCodeAction(GetAnyPhoneNumber())
            .AsFast();

        create.Execute();
        
        AssertParametersContain("fast", "1");
    }
    
    [TestMethod]
    public void create_with_content()
    {
        var content = "any content";
        var create = CreateMfaCodeAction(GetAnyPhoneNumber())
            .WithContent(content);

        create.Execute();
        
        AssertParametersContain("content", content);
    }
    
    [TestMethod]
    public void create_with_sendername()
    {
        var sendername = "abc";
        var create = CreateMfaCodeAction(GetAnyPhoneNumber())
            .FromSendername(sendername);

        create.Execute();
        
        AssertParametersContain("from", sendername);
    }

    private static string GetAnyPhoneNumber() => "48500100100";

    private CreateMFACode CreateMfaCodeAction(string phoneNumber)
    {
        var action = new CreateMFACode(phoneNumber);
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
    
    private void AssertParametersDoesNotContain(string name)
    {
        Assert.IsFalse(
            _spyProxy.Parameters.ContainsKey(name),
            $"Key not expected {name}"
        );
    }
}
