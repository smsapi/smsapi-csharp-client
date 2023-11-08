using System;
using System.Collections.Generic;
using System.IO;
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
public class RestJsonResponseDeserializerTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void throw_custom_action_exception()
    {
        var action = new TestAction();
        action.Proxy(_proxyStub);
        Dictionary<string, dynamic> response = new();
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.RequestTimeout
        );

        var execution = () => action.Execute();

        var expectedMessage = "expired";
        Assert.ThrowsException<CustomException>(execution, expectedMessage);
    }

    [TestMethod]
    public void deserialize_to_object_when_no_exception_mapper_found()
    {
        var action = new TestAction();
        action.Proxy(_proxyStub);
        Dictionary<string, dynamic> response = new() { { "TestProperty", "abc" } };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = action.Execute();

        Assert.AreEqual("abc", result.TestProperty);
    }

    private class TestAction : Base<ResponseWithExceptionMapper>
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

    [DataContract]
    private class ResponseWithExceptionMapper : IResponseCodeAwareResolver
    {
        [DataMember] public string TestProperty;

        public Dictionary<int, Action<Stream>> HandleExceptionActions()
        {
            return new Dictionary<int, Action<Stream>>
            {
                { 408, _ => throw new CustomException("expired", 408) }
            };
        }
    }

    private class CustomException : ClientException
    {
        public CustomException(string message, int code) : base(message, code)
        {
        }
    }
}
