using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;
using smsapi.Api.Response.REST.Exception;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class DeleteShortUrlResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void delete_short_url()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            DictionaryToStreamHelper.EmptyStream,
            HttpStatusCode.NoContent
        );

        DeleteShortUrl("any id").Execute();

        Assert.IsTrue(true);
    }

    [TestMethod]
    public void map_not_found_error_when_delete()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            DictionaryToStreamHelper.EmptyStream,
            HttpStatusCode.NotFound
        );

        var action = () => { _ = DeleteShortUrl("any id").Execute(); };

        Assert.ThrowsException<NotFoundException>(action);
    }

    private DeleteShortUrl DeleteShortUrl(string id)
    {
        var action = new DeleteShortUrl(id);
        action.Proxy(_proxyStub);

        return action;
    }
}
