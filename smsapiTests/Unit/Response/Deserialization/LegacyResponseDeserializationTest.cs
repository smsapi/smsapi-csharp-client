using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using SMSApi.Api.Response.ResponseResolver;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Response.Deserialization;

[TestClass]
public class LegacyResponseDeserializationTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void map_response_to_object()
    {
        var action = new TestAction();
        action.Proxy(_proxyStub);
        var testValue = "test value";
        Dictionary<string, dynamic> errorResponse = new() { { "TestProperty", testValue } };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            errorResponse.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = action.Execute();

        Assert.AreEqual(testValue, result.TestProperty);
    }

    private class TestAction : Base<BaseResponse>
    {
        protected override RequestMethod Method { get; }

        protected override string Uri()
        {
            return "";
        }
    }

    [DataContract]
    private class BaseResponse : ErrorAwareResponse
    {
        [DataMember] public string TestProperty;
    }
}