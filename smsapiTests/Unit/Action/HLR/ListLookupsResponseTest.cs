using System;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using SMSApi.Api.Response.Common.Telephony;
using SMSApi.Api.Response.HLR;
using smsapiTests.Unit.Action.HLR.Fixture;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Blacklist;

[TestClass]
public class ListLookupsResponseTest
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
    public void list_lookups_with_result()
    {
        var id = "655B26893332330011B0B297";
        var phoneNumber = "48500100100";
        var @interface = "api";
        var country = new Country("Poland", 260);
        var network = new Network("T-Mobile", 3);
        var cost = new LookupCost(1.08);
        var sentAt = DateTime.Now;
        var response = LookupsCollectionMother.Lookups(
            id,
            phoneNumber,
            @interface,
            country,
            network,
            cost,
            null,
            null,
            sentAt
        );
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(1, result.Size);
        var firstElement = result.Collection.First();
        Assert.AreEqual(id, firstElement.Id);
        Assert.AreEqual(phoneNumber, firstElement.PhoneNumber);
        Assert.AreEqual(@interface, firstElement.Interface);
        Assert.AreEqual(country, firstElement.Country);
        Assert.AreEqual(network, firstElement.Network);
        Assert.AreEqual(cost, firstElement.Cost);
        Assert.AreEqual(null, firstElement.Ported);
        Assert.AreEqual(null, firstElement.ErrorCode);
        Assert.AreEqual(sentAt, firstElement.SentAt);
    }
    
    [TestMethod]
    public void list_lookups_with_error()
    {
        var id = "655B26893332330011B0B297";
        var phoneNumber = "48500100100";
        var @interface = "api";
        var cost = new LookupCost(1.08);
        var sentAt = DateTime.Now;
        var response = LookupsCollectionMother.Lookups(
            id,
            phoneNumber,
            @interface,
            null,
            null,
            cost,
            null,
            15,
            sentAt
        );
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetList().Execute();

        Assert.AreEqual(1, result.Size);
        var firstElement = result.Collection.First();
        Assert.AreEqual(id, firstElement.Id);
        Assert.AreEqual(phoneNumber, firstElement.PhoneNumber);
        Assert.AreEqual(@interface, firstElement.Interface);
        Assert.AreEqual(null, firstElement.Country);
        Assert.AreEqual(null, firstElement.Network);
        Assert.AreEqual(null, firstElement.Ported);
        Assert.AreEqual(cost, firstElement.Cost);
        Assert.AreEqual(sentAt, firstElement.SentAt);
        Assert.AreEqual(15u, firstElement.ErrorCode);
    }

    private ListLookups GetList()
    {
        var action = new ListLookups();
        action.Proxy(_proxyStub);

        return action;
    }
}