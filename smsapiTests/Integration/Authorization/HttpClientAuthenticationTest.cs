using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Integration.Authorization;

[TestClass]
public class HttpClientAuthenticationTest : IntegrationTestBase
{
    [TestMethod]
    public void request_contains_oauth_authentication_header()
    {
        var token = "any token";
        var client = new ClientOAuth(token);
        var smsFactory = new SMSFactory(client, GetProxy());

        SendAnyMessage(smsFactory);

        var expectedAuthHeader = $"Bearer {token}";
        RequestAssert.AssertContainsAuthorizationHeader(expectedAuthHeader);
    }

    private static void SendAnyMessage(SMSFactory smsFactory)
    {
        SendActionHelper.SendAnySms(smsFactory);
    }
}
