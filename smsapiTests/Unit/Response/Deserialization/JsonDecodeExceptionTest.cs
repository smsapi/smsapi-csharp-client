using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SMSApi.Api;
using SMSApi.Api.Action;
using smsapiTests.Unit.Fixture;

namespace smsapiTests.Unit.Response.Deserialization;

[TestClass]
public class JsonDecodeExceptionTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void exception_contains_api_response_when_deserialization_fails()
    {
        var body = "{\"value\":\"not a number\"}";
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            Task.FromResult<Stream>(new MemoryStream(Encoding.UTF8.GetBytes(body))),
            HttpStatusCode.OK
        );
        var action = new TestAction();
        action.Proxy(_proxyStub);

        var ex = Assert.ThrowsException<HostException>(() => action.Execute());

        Assert.AreEqual(HostException.E_JSON_DECODE, ex.Code);
        Assert.AreEqual(body, ex.Response);
        Assert.IsInstanceOfType(ex.InnerException, typeof(JsonException));
    }

    private class TestAction : Action<TestResponse>
    {
        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri() => "";
    }

    private class TestResponse
    {
        public readonly int Value;
    }
}
