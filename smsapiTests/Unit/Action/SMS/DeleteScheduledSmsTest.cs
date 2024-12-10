using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action;

namespace smsapiTests.Unit.SMS;

[TestClass]
public class DeleteScheduledSmsTest
{
    private readonly ProxyAssert _proxyAssert;
    private readonly SpyProxy _spyProxy = new();

    public DeleteScheduledSmsTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void see_correct_uri()
    {
        CreateAction("any").Execute();

        _proxyAssert.AssertUriEquals("sms.do");
    }

    [TestMethod]
    public void delete_one_message()
    {
        var id = "anyId";

        CreateAction(id).Execute();

        _proxyAssert.AssertParametersContain("sch_del", id);
    }

    [TestMethod]
    public void delete_few_message()
    {
        string[] ids = { "first", "second" };

        CreateAction(ids).Execute();

        var expectedParams = $"{ids[0]},{ids[1]}";
        _proxyAssert.AssertParametersContain("sch_del", expectedParams);
    }

    [TestMethod]
    public void skip_duplicates()
    {
        string[] ids = { "duplicate", "duplicate" };

        CreateAction(ids).Execute();

        var expectedParams = "duplicate";
        _proxyAssert.AssertParametersContain("sch_del", expectedParams);
    }

    private SMSDelete CreateAction(params string[] id)
    {
        var action = new SMSDelete(id);
        action.Proxy(_spyProxy);

        return action;
    }
}
