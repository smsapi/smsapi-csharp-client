using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Blacklist;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Blacklist;

[TestClass]
public class AddResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void blacklist_response()
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
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.Created
        );

        var result = AddAction(phoneNumber).Execute();
        
        Assert.AreEqual(id, result.Id);
        Assert.AreEqual(phoneNumber, result.PhoneNumber);
        Assert.AreEqual(DateTime.Parse(createdAt), result.DateCreated);
        Assert.AreEqual(expireAt, result.DateExpired);
    }

    private Add AddAction(string phoneNumber)
    {
        var action = new Add(phoneNumber);
        action.Proxy(_proxyStub);

        return action;
    }
}
