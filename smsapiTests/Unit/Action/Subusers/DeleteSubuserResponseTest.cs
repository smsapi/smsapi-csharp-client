using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Subusers.Creation;
using smsapi.Api.Response.REST.Exception;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Subusers;

[TestClass]
public class DeleteSubuserResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void delete_subuser()
    {
        var subuserId = "1238f47da26ee45dc41fb987";
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            DictionaryToStreamHelper.EmptyStream,
            HttpStatusCode.NoContent
        );

        DeleteSubuser(subuserId);

        Assert.IsTrue(true);
    }

    [TestMethod]
    public void map_http_404_to_not_found_exception()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            DictionaryToStreamHelper.EmptyStream,
            HttpStatusCode.NotFound
        );

        var result = () => { DeleteSubuser(); };

        Assert.ThrowsException<NotFoundException>(result);
    }

    private void DeleteSubuser(string userId = "any")
    {
        var action = new DeleteSubuser(userId);
        action.Proxy(_proxyStub);

        action.Execute();
    }
}
