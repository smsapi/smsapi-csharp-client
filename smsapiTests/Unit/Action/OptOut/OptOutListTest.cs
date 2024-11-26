using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.OptOut;

namespace smsapiTests.Unit.Action.OptOut;

[TestClass]
public class OptOutListTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public OptOutListTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        CreateOptOutList().Execute();
        
        _proxyAssert.AssertUriEquals("opt_outs");
    }
    
    [TestMethod]
    public void valid_uri_with_phone_number_filtering()
    {
        var phoneNumberToFilterBy = "48500100100";
        
        CreateOptOutList()
            .FilterByPhoneNumber(phoneNumberToFilterBy)
            .Execute();
        
        _proxyAssert.AssertUriEquals($"opt_outs?phone_number={phoneNumberToFilterBy}");
    }
    
    [TestMethod]
    public void valid_method()
    {
        CreateOptOutList().Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }

    private OptOutList CreateOptOutList()
    {
        var action = new OptOutList();
        action.Proxy(_spyProxy);

        return action;
    }
}
