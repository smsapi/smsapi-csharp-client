using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Integration.Authorization;

[TestClass]
public class HttpClientAuthenticationTest : IntegrationTestBase
{
    [TestInitialize]
    public void InitializeServer()
    {
        RunTestServer();
    }

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

    [TestMethod]
    public void request_contains_basic_authentication_header()
    {
        var username = "any token";
        var password = "password";
        var client = new Client(username, password);
        var smsFactory = new SMSFactory(client, GetProxy());

        SendAnyMessage(smsFactory);

        var expectedAuthHeader = GetBase64String(username, password);
        RequestAssert.AssertContainsAuthorizationHeader($"Basic {expectedAuthHeader}");
    }

    private string GetBase64String(string username, string password)
    {
        return Convert.ToBase64String(
            Encoding.UTF8.GetBytes($"{username}:{password}")
        );
    }

    private static void SendAnyMessage(SMSFactory smsFactory)
    {
        SendActionHelper.SendAnySms(smsFactory);
    }
}
