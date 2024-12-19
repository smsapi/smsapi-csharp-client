using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Subusers.Creation;
using SMSApi.Api.Response.Subusers;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Subusers;

[TestClass]
public class EditSubuserResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    [DataRow(true)]
    [DataRow(false)]
    public void edit_subuser(bool active)
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
            HttpStatusCode.Created
        );

        var result = EditSubuser();

        Assert.AreEqual(id, result.Id);
        Assert.AreEqual(username, result.Username);
        Assert.AreEqual(active, result.Active);
        Assert.AreEqual(description, result.Description);
        Assert.AreEqual(new UserPoints(fromAccountPoints, perMonthPoints), result.Points);
    }

    private SubuserDetails EditSubuser()
    {
        var action = new EditSubuser("any");
        action.Proxy(_proxyStub);

        return action.Execute();
    }
}
