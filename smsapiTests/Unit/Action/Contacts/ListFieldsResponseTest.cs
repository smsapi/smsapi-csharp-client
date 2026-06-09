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
public class ListFieldsResponseTest
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
    public void list_fields()
    {
        var response = CollectionMother.WithItems(
            new Dictionary<string, dynamic>
            {
                { "id", "1" },
                { "name", "FieldA" },
                { "type", "TEXT" }
            },
            new Dictionary<string, dynamic>
            {
                { "id", "2" },
                { "name", "FieldB" },
                { "type", "NUMBER" }
            });
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(2, result.Size);
        Assert.AreEqual(2, result.Collection.Count);
        var firstField = result.Collection.First();
        Assert.AreEqual("1", firstField.Id);
        Assert.AreEqual("FieldA", firstField.Name);
        Assert.AreEqual("TEXT", firstField.Type);
    }

    private ListFields GetList()
    {
        var action = new ListFields();
        action.Proxy(_proxyStub);

        return action;
    }
}
