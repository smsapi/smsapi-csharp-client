using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Blacklist;
using SMSApi.Api.Response.Blacklist.Exception;
using smsapi.Api.Response.REST.Exception;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Blacklist;

[TestClass]
public class RemoveResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void try_remove_non_existing()
    {
        //given
        var response = new Dictionary<string, dynamic>();
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.NotFound
        );
        var nonExistingId = "5A5359173738303F2F95B7E2";
        
        //then
        var action = () => Remove(nonExistingId).Execute();

        //when
        Assert.ThrowsException<BlacklistRecordDoesNotExistException>(action);
    }

    [TestMethod]
    public void non_existing_record_is_catchable_as_not_found()
    {
        var response = new Dictionary<string, dynamic>();
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.NotFound
        );
        var nonExistingId = "5A5359173738303F2F95B7E2";

        var action = () => Remove(nonExistingId).Execute();

        var exception = Assert.ThrowsException<BlacklistRecordDoesNotExistException>(action);
        Assert.IsInstanceOfType(exception, typeof(NotFoundException));
    }

    [TestMethod]
    public void remove_existing_record()
    {
        var response = new Dictionary<string, dynamic>();
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.NoContent
        );
        var existingId = "5A5359173738303F2F95B7E2";
        
        Remove(existingId).Execute();

        Assert.IsTrue(true);
    }

    private Remove Remove(string id)
    {
        var action = new Remove(id);
        action.Proxy(_proxyStub);

        return action;
    }
}
