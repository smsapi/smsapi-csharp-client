using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Subusers;

namespace smsapiTests.Unit.Action.Subusers;

[TestClass]
public class GetSubuserTest
{
    private readonly ProxyAssert _proxyAssert;
    private readonly SpyProxy _spyProxy = new();

    public GetSubuserTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void use_get_request_method()
    {
        GetSubuser().Execute();

        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }

    [TestMethod]
    public void request_proper_uri()
    {
        var userId = "1238f47da26ee45dc41fb987";

        GetSubuser(userId).Execute();

        _proxyAssert.AssertUriEquals($"subusers/{userId}");
    }

    private GetSubuser GetSubuser(string id = "any")
    {
        var action = new GetSubuser(id);
        action.Proxy(_spyProxy);

        return action;
    }
}
