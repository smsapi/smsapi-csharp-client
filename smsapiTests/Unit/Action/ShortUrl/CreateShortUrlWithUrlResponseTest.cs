using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;
using SMSApi.Api.Response.ShortUrl.Exception;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class CreateShortUrlWithUrlResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void create_opt_out()
    {
        var id = "655B26893332330011B0B297";
        var name = "short link";
        var url = "https://example.com";
        var shortUrl = "https://example.com";
        object? filename;
        filename = null;
        var type = "link";
        var expirationDate = "2024-11-26T14:20:53+01:00";
        var hits = 0;
        var uniqueHits = 0;
        var description = "fancy link";
        var response =
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
            };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = CreateShortUrl(name, url).Execute();

        Assert.AreEqual(id, result.Id);
        Assert.AreEqual(name, result.Name);
        Assert.AreEqual(url, result.Url);
        Assert.AreEqual(shortUrl, result.ShortUrl);
        Assert.AreEqual(filename, result.FileName);
        Assert.AreEqual(type, result.Type);
        Assert.AreEqual(DateTime.Parse(expirationDate), result.ExpireAt);
        Assert.AreEqual(hits, result.Hits);
        Assert.AreEqual(uniqueHits, result.UniqueHits);
        Assert.AreEqual(description, result.Description);
    }

    [TestMethod]
    public void see_conflict_response()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            null,
            HttpStatusCode.Conflict
        );

        var action = () => CreateShortUrl("any", "http://any.com").ExecuteAsync();

        Assert.ThrowsExceptionAsync<ShortUrlWithNameAlreadyExistsException>(action);
    }

    private CreateShortUrl CreateShortUrl(string name, string url)
    {
        var action = new CreateShortUrl(name, url);
        action.Proxy(_proxyStub);

        return action;
    }
}
