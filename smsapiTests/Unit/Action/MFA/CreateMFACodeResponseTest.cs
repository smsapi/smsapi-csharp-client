using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.MFA;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.MFA;

[TestClass]
public class CreateMFACodeResponseTest
{
    private readonly ProxyStub _proxyStub = new();
    
    [TestMethod]
    public void map_result_to_object()
    {
        var id = "5ADEF4DC3738305BEED02B0C";
        var code = "123456";
        var phoneNumber = "48500500500";
        var from = "Test";
        var response = new Dictionary<string, dynamic>
        {
            {
                "id", id
            },
            {
                "code", code
            },
            {
                "phone_number", phoneNumber
            },
            {
                "from", from
            },
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );
        
        var result = CreateMfaCodeAction(GetAnyPhoneNumber()).Execute();
        
        Assert.AreEqual(id, result.Id);
        Assert.AreEqual(code, result.Code);
        Assert.AreEqual(phoneNumber, result.PhoneNumber);
        Assert.AreEqual(from, result.From);
    }

    private static string GetAnyPhoneNumber() => "48500100100";

    private CreateMFACode CreateMfaCodeAction(string phoneNumber)
    {
        var action = new CreateMFACode(phoneNumber);
        action.Proxy(_proxyStub);

        return action;
    }
}
