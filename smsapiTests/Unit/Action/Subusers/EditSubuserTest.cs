using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Subusers.Creation;

namespace smsapiTests.Unit.Action.Subusers;

[TestClass]
public class EditSubuserTest
{
    private readonly ProxyAssert _proxyAssert;
    private readonly SpyProxy _spyProxy = new();

    public EditSubuserTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void use_put_request_method()
    {
        EditSubuser().Execute();

        _proxyAssert.AssertRequestMethod(RequestMethod.PUT);
    }

    [TestMethod]
    public void request_proper_uri()
    {
        var userId = "1238f47da26ee45dc41fb987";

        EditSubuser(userId).Execute();

        _proxyAssert.AssertUriEquals($"subusers/{userId}");
    }

    [TestMethod]
    public void do_not_change_anything_when_not_requested()
    {
        EditSubuser().Execute();

        _proxyAssert.AssertNoParameters();
    }

    [TestMethod]
    public void activate_user()
    {
        EditSubuser()
            .Activate()
            .Execute();

        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("active", true);
    }

    [TestMethod]
    public void deactivate_user()
    {
        EditSubuser()
            .Deactivate()
            .Execute();

        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("active", false);
    }

    [TestMethod]
    public void change_password()
    {
        var newPassword = "newPassword";

        EditSubuser()
            .ChangePassword(newPassword)
            .Execute();

        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("credentials", new Dictionary<string, string> { { "password", newPassword } });
    }

    [TestMethod]
    public void change_description()
    {
        var newDescription = "any description";

        EditSubuser()
            .ChangeDescription(newDescription)
            .Execute();

        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("description", newDescription);
    }

    [TestMethod]
    public void do_not_change_points_when_empty()
    {
        var emptyPoints = new SubuserPoints();

        EditSubuser()
            .ChangePoints(emptyPoints)
            .Execute();

        _proxyAssert.AssertNoParameters();
    }

    [TestMethod]
    public void send_only_from_account_points_value()
    {
        var fromAccount = 10;
        var points = new SubuserPoints(fromAccount);

        EditSubuser()
            .ChangePoints(points)
            .Execute();

        var expectedPoints = new Dictionary<string, double> { { "from_account", fromAccount } };
        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("points", expectedPoints);
    }

    [TestMethod]
    public void send_only_per_month_points_value()
    {
        var perMonth = 10;
        var points = new SubuserPoints(PerMonth: perMonth);

        EditSubuser()
            .ChangePoints(points)
            .Execute();

        var expectedPoints = new Dictionary<string, double> { { "per_month", perMonth } };
        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("points", expectedPoints);
    }

    [TestMethod]
    public void send_from_account_and_per_month_points_value()
    {
        var fromAccount = 15;
        var perMonth = 10;
        var points = new SubuserPoints(fromAccount, perMonth);

        EditSubuser()
            .ChangePoints(points)
            .Execute();

        var expectedPoints = new Dictionary<string, double>
        {
            { "from_account", fromAccount },
            { "per_month", perMonth }
        };
        _proxyAssert
            .AssertParametersCount(1)
            .AssertParametersContain("points", expectedPoints);
    }

    private EditSubuser EditSubuser(string userId = "any")
    {
        var action = new EditSubuser(userId);
        action.Proxy(_spyProxy);

        return action;
    }
}
