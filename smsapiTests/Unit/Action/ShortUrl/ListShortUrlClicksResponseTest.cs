using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class ListShortUrlClicksResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void list_clicks()
    {
        var phoneNumber = "48500100100";
        var hitDate = "2024-11-26T14:20:53+01:00";
        var name = "short link";
        var shortUrl = "https://example.com";
        var os = "Linux";
        var browser = "Firefox 16.1";
        var device = "Mobile device";

        var response =
            new Dictionary<string, dynamic>
            {
                { "phone_number", phoneNumber },
                { "date_hit", hitDate },
                { "name", name },
                { "short_url", shortUrl },
                { "os", os },
                { "browser", browser },
                { "device", device }
            };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            CollectionMother.WithItems(response).ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = ListShortUrlClicks().Execute();

        Assert.AreEqual(1, result.Size);
        Assert.AreEqual(1, result.Collection.Count);
        var firstClick = result.Collection.First();
        Assert.AreEqual(phoneNumber, firstClick.PhoneNumber);
        Assert.AreEqual(DateTime.Parse(hitDate), firstClick.DateHit);
        Assert.AreEqual(name, firstClick.Name);
        Assert.AreEqual(shortUrl, firstClick.ShortUrl);
        Assert.AreEqual(os, firstClick.Os);
        Assert.AreEqual(browser, firstClick.Browser);
        Assert.AreEqual(device, firstClick.Device);
    }

    private ListShortUrlClicks ListShortUrlClicks()
    {
        var action = new ListShortUrlClicks();
        action.Proxy(_proxyStub);

        return action;
    }
}
