using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using SMSApi.Api.Response.ResponseResolver;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Response.Deserialization;

[TestClass]
public class LegacyResponseDeserializationExceptionTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    [DynamicData(nameof(ClientErrorCodes), DynamicDataSourceType.Method)]
    public void throw_client_exception(int errorCode)
    {
        var action = new TestAction();
        action.Proxy(_proxyStub);
        Dictionary<string, dynamic> errorResponse = new() { { "error", errorCode } };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            errorResponse.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var execution = () => action.Execute();

        Assert.ThrowsException<ClientException>(execution);
    }
    
    [TestMethod]
    [DynamicData(nameof(HostErrorCodes), DynamicDataSourceType.Method)]
    public void throw_host_exception(int errorCode)
    {
        var action = new TestAction();
        action.Proxy(_proxyStub);
        Dictionary<string, dynamic> errorResponse = new() { { "error", errorCode } };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            errorResponse.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var execution = () => action.Execute();

        Assert.ThrowsException<HostException>(execution);
    }

    private static IEnumerable<object[]> ClientErrorCodes()
    {
        return new[]
        {
            new object[] {101},
            new object[] {102},
            new object[] {103},
            new object[] {105},
            new object[] {110},
            new object[] {1000},
            new object[] {1001},
        };
    }
    
    private static IEnumerable<object[]> HostErrorCodes()
    {
        return new[]
        {
            new object[] {8},
            new object[] {201},
            new object[] {666},
            new object[] {999},
        };
    }

    private class TestAction : Action<ErrorAwareResponse>
    {
        protected override RequestMethod Method { get; }

        protected override string Uri()
        {
            return "";
        }
    }

    private class BaseResponse : ErrorAwareResponse
    {
    }
}
