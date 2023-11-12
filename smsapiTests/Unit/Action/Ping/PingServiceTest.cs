using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Ping;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Ping;

[TestClass]
public class PingServiceTest
{
    private readonly ProxyStub _proxyStub = new();
    
    [TestMethod]
    [DataRow(true)]
    [DataRow(false)]
    public void authorized_status(bool authorized)
    {
        var response = new Dictionary<string, dynamic>
        {
            {
                "authorized", authorized
            },
            {
                "unavailable", new List<string>()
            }
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );
        
        var result = Ping().Execute();
        
        Assert.AreEqual(authorized, result.Authorized);
        Assert.AreEqual(0, result.UnavailableServices.Count());
    }
    
    [TestMethod]
    public void unavailable_list()
    {
        var unavailableService = "fancy service";
        var response = new Dictionary<string, dynamic>
        {
            {
                "authorized", true
            },
            {
                "unavailable", new List<string> {unavailableService}
            }
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );
        
        var result = Ping().Execute();
        
        Assert.AreEqual(1, result.UnavailableServices.Count());
        Assert.AreEqual(unavailableService, result.UnavailableServices.First());
    }
    
    private PingService Ping()
    {
        var action = new PingService();
        action.Proxy(_proxyStub);

        return action;
    }
}
