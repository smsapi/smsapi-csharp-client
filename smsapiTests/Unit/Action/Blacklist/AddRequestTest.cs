using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action.Blacklist;

namespace smsapiTests.Unit.Action.Blacklist;

[TestClass]
public class AddRequestTest
{
    private readonly SpyProxy _proxySpy = new();
    private readonly ProxyAssert _proxyAssert;

    public AddRequestTest()
    {
        _proxyAssert = new ProxyAssert(_proxySpy);
    }

    [TestMethod]
    public void request_contains_only_phone_number()
    {
        var phoneNumber = "48500000000";
        var action = AddAction(phoneNumber);

        action.Execute();
        
        _proxyAssert.AssertParametersContain("phone_number", phoneNumber);
        _proxyAssert.AssertParametersDoesNotContain("expire_at");
    }
    
    [TestMethod]
    public void request_contains_expiration_date()
    {
        var expirationDate = DateTimeOffset.Now;
        var action = AddAction("48500000000")
            .WithExpireAt(expirationDate);

        action.Execute();
        
        _proxyAssert.AssertParametersContain("expire_at", expirationDate.ToString("O"));
    }

    private Add AddAction(string phoneNumber)
    {
        var action = new Add(phoneNumber);
        action.Proxy(_proxySpy);

        return action;
    }
}
