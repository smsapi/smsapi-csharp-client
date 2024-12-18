using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action.Subusers.Creation;
using smsapiTests.Unit.Action.Subusers.Fixture;

namespace smsapiTests.Unit.Action.Subusers;

[TestClass]
public class CreateSubuserTest
{
    private readonly ProxyAssert _proxyAssert;
    private readonly SpyProxy _spyProxy = new();

    public CreateSubuserTest()
    {
        _proxyAssert = new ProxyAssert(_spyProxy);
    }

    [TestMethod]
    public void use_post_request_method()
    {
        CreateSubuser(SubuserCredentialsMother.Any()).Execute();

        _proxyAssert.AssertRequestMethod(RequestMethod.POST);
    }

    [TestMethod]
    public void request_proper_uri()
    {
        CreateSubuser(SubuserCredentialsMother.Any()).Execute();

        _proxyAssert.AssertUriEquals("subusers");
    }

    [TestMethod]
    public void default_activity_is_false()
    {
        CreateSubuser(SubuserCredentialsMother.Any()).Execute();

        _proxyAssert
            .AssertParametersCount(2) //credentials + active
            .AssertParametersContain("active", false);
    }

    [TestMethod]
    public void make_user_active()
    {
        CreateSubuser(SubuserCredentialsMother.Any())
            .AsActive()
            .Execute();

        _proxyAssert
            .AssertParametersCount(2) //credentials + active
            .AssertParametersContain("active", true);
    }

    [TestMethod]
    public void request_contains_credentials()
    {
        var username = "new_username";
        var password = "password";
        var apiPassword = "api_password";
        var credentials = new SubuserCredentials(username, password, apiPassword);

        CreateSubuser(credentials).Execute();

        var expectedCredentials = new Dictionary<string, string>
        {
            { "username", username },
            { "password", password },
            { "api_password", apiPassword }
        };
        _proxyAssert
            .AssertParametersCount(2) //credentials + active
            .AssertParametersContain("credentials", expectedCredentials);
    }

    [TestMethod]
    public void set_description()
    {
        var description = "any description";
        CreateSubuser(SubuserCredentialsMother.Any())
            .WithDescription(description)
            .Execute();

        _proxyAssert
            .AssertParametersCount(3) //credentials + active
            .AssertParametersContain("description", description);
    }

    [TestMethod]
    public void do_not_send_points_when_empty()
    {
        var points = new SubuserPoints();
        CreateSubuser(SubuserCredentialsMother.Any())
            .WithPoints(points)
            .Execute();

        _proxyAssert
            .AssertParametersCount(2) //credentials + active
            .AssertParametersDoesNotContain("points");
    }

    [TestMethod]
    public void send_only_from_account_points_value()
    {
        var fromAccount = 10;
        var points = new SubuserPoints(fromAccount);
        CreateSubuser(SubuserCredentialsMother.Any())
            .WithPoints(points)
            .Execute();

        var expectedPoints = new Dictionary<string, double> { { "from_account", fromAccount } };
        _proxyAssert
            .AssertParametersCount(3) //credentials + active
            .AssertParametersContain("points", expectedPoints);
    }

    [TestMethod]
    public void send_only_per_month_points_value()
    {
        var perMonth = 10;
        var points = new SubuserPoints(PerMonth: perMonth);
        CreateSubuser(SubuserCredentialsMother.Any())
            .WithPoints(points)
            .Execute();

        var expectedPoints = new Dictionary<string, double> { { "per_month", perMonth } };
        _proxyAssert
            .AssertParametersCount(3) //credentials + active
            .AssertParametersContain("points", expectedPoints);
    }

    [TestMethod]
    public void send_from_account_and_per_month_points_value()
    {
        var fromAccount = 15;
        var perMonth = 10;
        var points = new SubuserPoints(fromAccount, perMonth);
        CreateSubuser(SubuserCredentialsMother.Any())
            .WithPoints(points)
            .Execute();

        var expectedPoints = new Dictionary<string, double>
        {
            { "from_account", fromAccount },
            { "per_month", perMonth }
        };
        _proxyAssert
            .AssertParametersCount(3) //credentials + active
            .AssertParametersContain("points", expectedPoints);
    }

    private CreateSubuser CreateSubuser(SubuserCredentials credentials)
    {
        var action = new CreateSubuser(credentials);
        action.Proxy(_spyProxy);

        return action;
    }
}
