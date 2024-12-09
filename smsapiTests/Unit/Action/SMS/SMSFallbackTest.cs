using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action;

namespace smsapiTests.Unit.SMS;

[TestClass]
public class SMSFallbackTest : UnitTestBase<SMSSend>
{
    private readonly ProxyAssert _proxyAssert;

    public SMSFallbackTest()
    {
        _proxyAssert = new ProxyAssert(SpyProxy);
    }

    [TestMethod]
    public void see_vms_fallback_requested()
    {
        CreateAction()
            .WithFallback(SMSSend.SmsFallbacks.Vms)
            .Execute();

        var expectedFallback = new HashSet<Dictionary<string, string>>
        {
            new() { { "type", "vms" } }
        };
        _proxyAssert.AssertParametersContain("fallback", expectedFallback);
    }

    protected override SMSSend CreateAction()
    {
        var action = base.CreateAction();
        AddNecessaryParameters(action);

        return action;
    }

    private static void AddNecessaryParameters(SMSSend action)
    {
        action.SetText("any");
        action.SetTo("any");
    }
}
