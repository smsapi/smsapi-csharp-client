using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.OptOut;
using SMSApi.Api.Response.OptOut;
using SMSApi.Api.Response.OptOut.Exception;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.OptOut;

[TestClass]
public class DeleteOptOutResponseTest
{
    private readonly ProxyStub _proxyStub = new();
    
    [TestMethod]
    public void pass_when_opt_out_exists()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            new Dictionary<string, dynamic>().ToHttpEntityStreamTask(),
            HttpStatusCode.NoContent
        );
        
        DeleteOptOut().Execute();
        
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    public void throw_when_opt_out_does_not_exist()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            new Dictionary<string, dynamic>().ToHttpEntityStreamTask(),
            HttpStatusCode.NotFound
        );

        OptOutDeletionResponse Delete() => DeleteOptOut().Execute();

        Assert.ThrowsException<OptOutNotFoundException>((Func<OptOutDeletionResponse>)Delete);
    }

    private DeleteOptOut DeleteOptOut()
    {
        var action = new DeleteOptOut("any");
        action.Proxy(_proxyStub);

        return action;
    }
}
