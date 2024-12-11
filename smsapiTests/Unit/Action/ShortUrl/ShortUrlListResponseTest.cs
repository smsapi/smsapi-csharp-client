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
public class ShortUrlListResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void empty_list()
    {
        var response = CollectionMother.Empty();
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(0, result.Size);
    }

    [TestMethod]
    public void list_short_urls()
    {
        var id = "655B26893332330011B0B297";
        var name = "short link";
        var url = "https://example.com";
        var shortUrl = "https://example.com";
        object? filename;
        filename = null;
        var type = "link";
        var expirationDate = "2024-11-26T14:20:53+01:00";
        var hits = 2;
        var uniqueHits = 1;
        var description = "fancy link";
        var response = CollectionMother.WithItems(
            new Dictionary<string, dynamic>
            {
                { "id", id },
                { "name", name },
                { "url", url },
                { "short_url", shortUrl },
                { "filename", filename },
                { "type", type },
                { "expire", expirationDate },
                { "hits", hits },
                { "hits_unique", uniqueHits },
                { "description", description }
            });
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(1, result.Size);
        var firstElement = result.Collection.First();
        Assert.AreEqual(id, firstElement.Id);
        Assert.AreEqual(name, firstElement.Name);
        Assert.AreEqual(url, firstElement.Url);
        Assert.AreEqual(shortUrl, firstElement.ShortUrl);
        Assert.AreEqual(filename, firstElement.FileName);
        Assert.AreEqual(type, firstElement.Type);
        Assert.AreEqual(DateTime.Parse(expirationDate), firstElement.ExpireAt);
        Assert.AreEqual(hits, firstElement.Hits);
        Assert.AreEqual(uniqueHits, firstElement.UniqueHits);
        Assert.AreEqual(description, firstElement.Description);
    }

    private ShortUrlList GetList()
    {
        var action = new ShortUrlList();
        action.Proxy(_proxyStub);

        return action;
    }
}
