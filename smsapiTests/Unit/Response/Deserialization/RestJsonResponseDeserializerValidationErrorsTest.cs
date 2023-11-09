using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using smsapi.Api.Response.Deserialization.Exception;
using SMSApi.Api.Response.ResponseResolver;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Response.Deserialization;

[TestClass]
public class RestJsonResponseDeserializerValidationErrorsTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void map_validation_errors_to_message()
    {
        var action = new TestAction();
        action.Proxy(_proxyStub);
        Dictionary<string, dynamic> response = new()
        {
            {
                "message", "The value is not valid mobile number."
            },
            {
                "error", "invalid_request_data"
            },
            {
                "errors", new List<Dictionary<string, string>>
                {
                    new()
                    {
                        {
                            "message", "The value is not valid mobile number."
                        },
                        {
                            "error", "invalid_request_data"
                        }
                    }
                }
            }
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.BadRequest
        );

        var execution = () => action.Execute();
        
        var exception = Assert.ThrowsException<ValidationException>(execution);
        var expectedMessage = "invalid_request_data: The value is not valid mobile number.";
        Assert.AreEqual(expectedMessage, exception.Message);
        Assert.AreEqual("400", exception.Code);
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
