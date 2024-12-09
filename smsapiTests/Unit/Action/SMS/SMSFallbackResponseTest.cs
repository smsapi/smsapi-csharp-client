using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;
using smsapiTests.Unit.SMS.Fixture;

namespace smsapiTests.Unit.SMS;

[TestClass]
public class SMSFallbackResponseTest : UnitTestBase<SMSSend>
{
    private readonly ProxyStub _proxyStub;

    public SMSFallbackResponseTest()
    {
        _proxyStub = new ProxyStub();
    }

    [TestMethod]
    public void see_vms_fallback_requested()
    {
        var id = "1238f47da26ee45dc41fb987";
        var idx = "any idx";
        var dateSent = DateTime.Now.Ticks;
        var points = 2.01d;
        var response = SmsSendResponseMother.VmsFallback(
            id,
            idx,
            dateSent,
            points
        );
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );
        
        var result = CreateAction()
            .WithFallback(SMSSend.SmsFallbacks.Vms)
            .Execute();

        Assert.AreEqual(0, result.Count);
        Assert.AreEqual(0, result.List.Capacity);
        Assert.AreEqual(1, result.Fallbacks?.Count);
        Assert.AreEqual("vms", result.Fallbacks!.First().Key);
        
        var vmsFallbacks = result.Fallbacks!.First().Value;
        Assert.AreEqual(1, vmsFallbacks.Count);
        Assert.AreEqual(id, vmsFallbacks.List.First().Id);
        Assert.AreEqual(idx, vmsFallbacks.List.First().Idx);
        Assert.AreEqual(points, vmsFallbacks.List.First().Points);
        Assert.AreEqual(dateSent, vmsFallbacks.List.First().DateSent);
    }

    protected override SMSSend CreateAction()
    {
        var action = base.CreateAction();
        action.Proxy(_proxyStub);
        AddNecessaryParameters(action);

        return action;
    }

    private static void AddNecessaryParameters(SMSSend action)
    {
        action.SetText("any");
        action.SetTo("any");
    }
}
