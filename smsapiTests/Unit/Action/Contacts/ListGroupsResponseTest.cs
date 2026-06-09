using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Contacts;

[TestClass]
public class ListGroupsResponseTest
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
    public void list_groups()
    {
        var response = CollectionMother.WithItems(
            new Dictionary<string, dynamic>
            {
                { "id", "1" },
                { "name", "GroupA" },
                { "contacts_count", 5 }
            },
            new Dictionary<string, dynamic>
            {
                { "id", "2" },
                { "name", "GroupB" },
                { "contacts_count", 0 }
            });
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(2, result.Size);
        Assert.AreEqual(2, result.Collection.Count);
        var firstGroup = result.Collection.First();
        Assert.AreEqual("1", firstGroup.Id);
        Assert.AreEqual("GroupA", firstGroup.Name);
        Assert.AreEqual(5, firstGroup.ContactsCount);
    }

    private ListGroups GetList()
    {
        var action = new ListGroups();
        action.Proxy(_proxyStub);

        return action;
    }
}
