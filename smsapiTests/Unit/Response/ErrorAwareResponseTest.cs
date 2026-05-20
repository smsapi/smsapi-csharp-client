using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response.Deserialization;
using SMSApi.Api.Response.ResponseResolver;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Response;

[TestClass]
public class ErrorAwareResponseTest
{
    private readonly BaseJsonDeserializer _deserializer = new();

    [TestMethod]
    public void deserializes_string_error_code()
    {
        var json = "{\"message\":\"Cannot find contact\",\"error\":\"contact_not_found\",\"code\":404}";

        var result = Deserialize<ErrorAwareResponse>(json);

        Assert.AreEqual("contact_not_found", result.ErrorCode);
        Assert.AreEqual("Cannot find contact", result.ErrorMessage);
        Assert.IsTrue(result.IsError());
    }

    [TestMethod]
    public void deserializes_numeric_error_code_as_string()
    {
        var json = "{\"message\":\"unauthorized\",\"error\":101}";

        var result = Deserialize<ErrorAwareResponse>(json);

        Assert.AreEqual("101", result.ErrorCode);
        Assert.IsTrue(result.IsError());
    }

    [TestMethod]
    public void is_not_error_when_error_code_is_zero()
    {
        var json = "{\"error\":0}";

        var result = Deserialize<ErrorAwareResponse>(json);

        Assert.IsFalse(result.IsError());
    }

    [TestMethod]
    public void is_not_error_when_error_code_is_missing()
    {
        var json = "{\"message\":\"ok\"}";

        var result = Deserialize<ErrorAwareResponse>(json);

        Assert.IsFalse(result.IsError());
    }

    private T Deserialize<T>(string json)
    {
        var responseEntity = new HttpResponseEntity(json.ToHttpEntityStreamTask(), HttpStatusCode.OK);
        return _deserializer.Deserialize<T>(responseEntity).Result;
    }
}
