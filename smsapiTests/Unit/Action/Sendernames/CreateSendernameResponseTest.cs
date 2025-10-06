using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Sendernames;
using SMSApi.Api.Response.Sendernames;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Sendernames;

[TestClass]
public class CreateSendernameResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void map_response_to_sendername()
    {
        var createdAt = "2018-11-08T09:36:53+01:00";
        var isDefault = new Random().NextBoolean();
        var sender = "any sender";
        var status = "any status";
        var response = new Dictionary<string, dynamic>
        {
            { "created_at", createdAt },
            { "is_default", isDefault },
            { "sender", sender },
            { "status", status },
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.Created
        );

        var createdSendername = Create();
        
        Assert.AreEqual(DateTime.Parse(createdAt), createdSendername.CreatedAt);
        Assert.AreEqual(isDefault, createdSendername.IsDefault);
        Assert.AreEqual(sender, createdSendername.Sender);
        Assert.AreEqual(status, createdSendername.Status);
    }

    private Sendername Create()
    {
        var action = new CreateSendername("any");
        action.Proxy(_proxyStub);

        return action.Execute();
    }
}
