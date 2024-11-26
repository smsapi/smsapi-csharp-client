using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.OptOut;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.OptOut;

[TestClass]
public class OptOutListResponseTest
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
    public void list_opt_outs()
    {
        var id = "655B26893332330011B0B297";
        var phoneNumber = "48500100100";
        var creationTime = "2024-11-26T14:20:53+01:00";
        var response = CollectionMother.WithItems(
            new Dictionary<string, dynamic>
            {
                { "id", id },
                { "phone_number", phoneNumber },
                { "creation_time", creationTime }
            });
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(1, result.Size);
        var firstElement = result.Collection.First();
        Assert.AreEqual(id, firstElement.Id);
        Assert.AreEqual(phoneNumber, firstElement.PhoneNumber);
        Assert.AreEqual(DateTime.Parse(creationTime),  firstElement.CreationTime);
    }

    private OptOutList GetList()
    {
        var action = new OptOutList();
        action.Proxy(_proxyStub);

        return action;
    }
}
