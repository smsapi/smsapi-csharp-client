using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.ShortUrl;

namespace smsapiTests.Unit.Action.ShortUrl;

[TestClass]
public class ListShortUrlClicksTest
{
    private readonly SpyProxy _spyProxy = new();
    private readonly ProxyAssert _proxyAssert;

    public ListShortUrlClicksTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }
    
    [TestMethod]
    public void valid_uri()
    {
        CreateListShortUrlClicks().Execute();
        
        _proxyAssert.AssertUriEquals("short_url/clicks");
    }
    
    [TestMethod]
    public void get_for_list()
    {
        CreateListShortUrlClicks().Execute();
        
        _proxyAssert.AssertRequestMethod(RequestMethod.GET);
    }

    [TestMethod]
    public void empty_parameters_when_no_date_filtering()
    {
        CreateListShortUrlClicks().Execute();

        _proxyAssert.AssertNoParameters();
    }

    [TestMethod]
    public void filter_by_from_date()
    {
        var fromLiteral = "2024-12-13";
        var from = DateTime.Parse(fromLiteral);
        CreateListShortUrlClicks()
            .ListFrom(from)
            .Execute();

        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("date_from", fromLiteral);
    }

    [TestMethod]
    public void filter_by_to_date()
    {
        var toLiteral = "2024-12-13";
        var to = DateTime.Parse(toLiteral);
        CreateListShortUrlClicks()
            .ListTo(to)
            .Execute();

        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("date_to", toLiteral);
    }

    [TestMethod]
    public void filter_by_from_and_to_date()
    {
        CreateListShortUrlClicks()
            .ListFrom(DateTime.MinValue)
            .ListTo(DateTime.MaxValue)
            .Execute();

        _proxyAssert.AssertParametersCount(2);
    }

    private ListShortUrlClicks CreateListShortUrlClicks()
    {
        var action = new ListShortUrlClicks();
        action.Proxy(_spyProxy);

        return action;
    }
}
