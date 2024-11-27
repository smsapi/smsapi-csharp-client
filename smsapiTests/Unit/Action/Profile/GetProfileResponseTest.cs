using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Profile;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Profile;

[TestClass]
public class ProfileTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void see_profile_data()
    {
        var name = "fancy name";
        var username = "fancy_username";
        var email = "any@any.pl";
        var phoneNumber = "48500100100";
        var userType = "native";
        var points = 500.25d;
        var paymentType = "prepaid";

        var response = new Dictionary<string, dynamic>
        {
            { "name", name },
            { "username", username },
            { "email", email },
            { "phone_number", phoneNumber },
            { "user_type", userType },
            { "points", points },
            { "payment_type", paymentType }
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = CreateGetProfile().Execute();
        
        Assert.AreEqual(name, result.Name);
        Assert.AreEqual(username, result.Username);
        Assert.AreEqual(email, result.Email);
        Assert.AreEqual(phoneNumber, result.PhoneNumber);
        Assert.AreEqual(userType, result.UserType);
        Assert.AreEqual(points, result.Points);
        Assert.AreEqual(paymentType, result.PaymentType);
    }

    private GetProfile CreateGetProfile()
    {
        var action = new GetProfile();
        action.Proxy(_proxyStub);

        return action;
    }
}
