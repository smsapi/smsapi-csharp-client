using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Subusers;
using SMSApi.Api.Response.Subusers;
using smsapiTests.Unit.Action.HLR.Fixture;
using smsapiTests.Unit.Action.Subusers.Fixture;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Subusers;

[TestClass]
public class ListTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void empty_list()
    {
        var response = LookupsCollectionMother.EmptyCollection;
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(0, result.Size);
    }
    
    [TestMethod]
    public void list_subusers()
    {
        var id = "655B26893332330011B0B297";
        var username = "Fancy name";
        var active = true;
        var description = "Description abc";
        var points = new UserPoints(10, 5);
        var response = SubuersCollectionMother.Collection(id, username, active, description, points);
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();
        
        Assert.AreEqual(1, result.Size);
        var firstElement = result.Collection.First();
        Assert.AreEqual(id, firstElement.Id);
        Assert.AreEqual(id, firstElement.Id);
        Assert.AreEqual(username, firstElement.Username);
        Assert.AreEqual(active, firstElement.Active);
        Assert.AreEqual(description, firstElement.Description);
        Assert.AreEqual(points, firstElement.Points);
    }

    private List GetList()
    {
        var action = new List();
        action.Proxy(_proxyStub);

        return action;
    }
}
