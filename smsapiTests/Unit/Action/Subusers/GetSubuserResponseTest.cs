using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Subusers;
using smsapi.Api.Response.REST.Exception;
using SMSApi.Api.Response.Subusers;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Subusers;

[TestClass]
public class GetSubuserResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    [DataRow(true)]
    [DataRow(false)]
    public void get_subuser(bool active)
    {
        var id = "655B26893332330011B0B297";
        var username = "subuser_name";
        var description = "any description";
        var fromAccountPoints = Random.Shared.NextDouble();
        var perMonthPoints = Random.Shared.NextDouble();
        var response =
            new Dictionary<string, dynamic>
            {
                { "id", id },
                { "username", username },
                { "active", active },
                { "description", description },
                {
                    "points", new Dictionary<string, double>
                    {
                        { "from_account", fromAccountPoints },
                        { "per_month", perMonthPoints }
                    }
                }
            };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetSubuser();

        Assert.AreEqual(id, result.Id);
        Assert.AreEqual(username, result.Username);
        Assert.AreEqual(active, result.Active);
        Assert.AreEqual(description, result.Description);
        Assert.AreEqual(new UserPoints(fromAccountPoints, perMonthPoints), result.Points);
    }

    [TestMethod]
    public void map_http_404_to_not_found_exception()
    {
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            DictionaryToStreamHelper.EmptyStream,
            HttpStatusCode.NotFound
        );

        var result = () =>
        {
            GetSubuser();
        };

        Assert.ThrowsException<NotFoundException>(result);
    }

    private SubuserDetails GetSubuser()
    {
        var action = new GetSubuser("any");
        action.Proxy(_proxyStub);

        return action.Execute();
    }
}
