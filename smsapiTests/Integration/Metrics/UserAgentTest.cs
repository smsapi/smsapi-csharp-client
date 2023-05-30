using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsapiTests.Integration.Metrics;

[TestClass]
public class UserAgentTest : IntegrationTestBase
{
    [TestInitialize]
    public void InitializeServer()
    {
        RunTestServer();
    }

    [TestMethod]
    public void request_contains_user_agent_header()
    {
        SendActionHelper.SendAnySms(GetProxy());

        var expectedUserAgent = $"smsapi-csharp-client:{Assembly.GetExecutingAssembly().GetName().Version};{Environment.Version}";
        RequestAssert.AssertContainsUserAgentHeader(expectedUserAgent);
    }
}
