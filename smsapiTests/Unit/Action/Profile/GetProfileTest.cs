using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Profile;

namespace smsapiTests.Unit.Action.Profile;

[TestClass]
public class GetProfileResponseTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public GetProfileResponseTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void valid_uri()
    {
        CreateGetProfile().Execute();

        _proxyAssert.AssertUriEquals("profile");
    }

    [TestMethod]
    public void valid_method()
    {
        CreateGetProfile().Execute();

        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }

    private GetProfile CreateGetProfile()
    {
        var action = new GetProfile();
        action.Proxy(_spyProxy);

        return action;
    }
}
