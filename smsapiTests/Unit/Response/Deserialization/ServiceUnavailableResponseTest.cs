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
public class ServiceUnavailableResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void map_http_503_to_exception()
    {
        var action = new TestAction();
        action.Proxy(_proxyStub);
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            DictionaryToStreamHelper.EmptyStream,
            HttpStatusCode.ServiceUnavailable
        );

        var execution = () => action.Execute();

        Assert.ThrowsException<ServiceUnavailableException>(execution);
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