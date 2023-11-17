using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Blacklist;
using smsapiTests.Unit.Action.Profile.Prices.Fixture;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Blacklist;

[TestClass]
public class ListTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void empty_list()
    {
        var response = PricesCollectionMother.EmptyCollection();
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(0, result.Size);
    }

    [TestMethod]
    public void list_numbers()
    {
        var id = "1238f47da26ee45dc41fb987";
        var phoneNumber = "48500000000";
        var createdAt = "2018-11-08T09:36:53+01:00";
        object? expireAt = null;
        var response = new Dictionary<string, dynamic>
        {
            { "id", id },
            { "phone_number", phoneNumber },
            { "created_at", createdAt },
            { "expire_at", expireAt }
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            CollectionMother.WithItems(response).ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();
        
        Assert.AreEqual(1, result.Size);
        var firstElement = result.Collection.First();
        Assert.AreEqual(id, firstElement.Id);
        Assert.AreEqual(phoneNumber, firstElement.PhoneNumber);
        Assert.AreEqual(DateTime.Parse(createdAt), firstElement.DateCreated);
        Assert.AreEqual(expireAt, firstElement.DateExpired);
    }

    private List GetList()
    {
        var action = new List();
        action.Proxy(_proxyStub);

        return action;
    }
}