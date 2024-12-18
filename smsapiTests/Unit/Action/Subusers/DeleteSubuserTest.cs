using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Subusers.Creation;

namespace smsapiTests.Unit.Action.Subusers;

[TestClass]
public class DeleteSubuserTest
{
    private readonly ProxyAssert _proxyAssert;
    private readonly SpyProxy _spyProxy = new();

    public DeleteSubuserTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void use_delete_request_method()
    {
        DeleteSubuser();

        _proxyAssert.AssertRequestMethod(RequestMethod.DELETE);
    }

    [TestMethod]
    public void request_proper_uri()
    {
        var userId = "1238f47da26ee45dc41fb987";

        DeleteSubuser(userId);

        _proxyAssert.AssertUriEquals($"subusers/{userId}");
    }

    private void DeleteSubuser(string userId = "any")
    {
        var action = new DeleteSubuser(userId);
        action.Proxy(_spyProxy);

        action.Execute();
    }
}