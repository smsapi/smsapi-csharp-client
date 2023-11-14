using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using SMSApi.Api.Response.ResponseResolver;
using smsapi.Api.Response.REST.Exception;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Response.Deserialization;

[TestClass]
public class TooManyRequestsResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void map_validation_errors_to_message()
    {
        var action = new TestAction();
        action.Proxy(_proxyStub);
        Dictionary<string, dynamic> response = new();
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.TooManyRequests
        );

        var execution = () => action.Execute();
        
        Assert.ThrowsException<TooManyRequestsException>(execution);
    }

    private class TestAction : Action<ResponseWithExceptionMapper>
    {
        protected override RequestMethod Method { get; }

        protected override ApiType ApiType()
        {
            return SMSApi.Api.Action.ApiType.Rest;
        }

        protected override string Uri()
        {
            return "";
        }
    }

    private class ResponseWithExceptionMapper : IResponseCodeAwareResolver
    {
    }
}
