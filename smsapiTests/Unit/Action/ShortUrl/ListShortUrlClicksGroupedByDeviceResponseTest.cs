using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class ListShortUrlClicksGroupedByDeviceResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void list_grouped_clicks()
    {
        var linkId = "any";
        var clicks = new Dictionary<string, int>
        {
            { "android", 1 },
            { "ios", 2 },
            { "wp", 3 },
            { "other", 4 },
            { "sum", 10 }
        };

        var response =
            new Dictionary<string, dynamic>
            {
                { "link_id", linkId },
                { "clicks", clicks }
            };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            CollectionMother.WithItems(response).ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = CreateShortUrClicksGroupedByDevice().Execute();

        Assert.AreEqual(1, result.Size);
        Assert.AreEqual(1, result.Collection.Count);
        var firstLink = result.Collection[0];
        Assert.AreEqual(linkId, firstLink.LinkId);
        Assert.AreEqual(1, firstLink.Clicks.Android);
        Assert.AreEqual(2, firstLink.Clicks.Ios);
        Assert.AreEqual(3, firstLink.Clicks.Wp);
        Assert.AreEqual(4, firstLink.Clicks.Other);
        Assert.AreEqual(10, firstLink.Clicks.Sum);
    }

    private ListShortUrlClicksGroupedByDevice CreateShortUrClicksGroupedByDevice()
    {
        var action = new ListShortUrlClicksGroupedByDevice("anyId");
        action.Proxy(_proxyStub);

        return action;
    }
}
