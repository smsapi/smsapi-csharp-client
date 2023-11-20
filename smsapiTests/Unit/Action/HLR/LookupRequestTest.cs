using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action;

namespace smsapiTests.Unit.Action.Blacklist;

[TestClass]
public class LookupRequestTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public LookupRequestTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void uri_is_valid()
    {
        Lookup("48500100100").Execute();
        
        _proxyAssert.AssertUriEquals("hlr/lookups");
    }

    [TestMethod]
    public void parameters_contain_phone_number()
    {
        var phoneNumber = "48500100100";
        
        Lookup(phoneNumber).Execute();
        
        _proxyAssert.AssertParametersContain("phone_number", phoneNumber);
    }

    private Lookup Lookup(string id)
    {
        var action = new Lookup(id);
        action.Proxy(_spyProxy);

        return action;
    }
}
