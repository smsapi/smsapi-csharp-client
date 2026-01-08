using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Integration;

[TestClass]
public class ProxyPathTest : IntegrationTestBase
{
    protected override bool AutostartServer => false;

    [TestMethod]
    public void proxy_adds_trailing_slash()
    {
        var client = new ClientOAuth("any");
        var host = FreeHost();
        Assert.IsFalse(host.EndsWith("/"));
        InitializeServer(host);
        var smsFactory = new SMSFactory(client, GetProxy());

        SendAnyMessage(smsFactory);

        var expectedUri = host + "/sms.do";
        RequestAssert.AsserRawPath(expectedUri);
    }

    private static void SendAnyMessage(SMSFactory smsFactory)
    {
        SendActionHelper.SendAnySms(smsFactory);
    }
}
