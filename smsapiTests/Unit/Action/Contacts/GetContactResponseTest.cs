using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action.Contacts;

[TestClass]
public class GetContactResponseTest
{
    private readonly ProxyStub _proxyStub = new();

    [TestMethod]
    public void get_contact()
    {
        var dateCreated = "2024-11-26T14:20:53+01:00";
        var dateUpdated = "2024-11-27T10:00:00+01:00";
        var birthdayDate = "1990-01-15";
        var response = new Dictionary<string, dynamic>
        {
            { "id", "5A5359173738303F2F95B7E2" },
            { "first_name", "Jan" },
            { "last_name", "Kowalski" },
            { "phone_number", "48500100100" },
            { "email", "jan@example.com" },
            { "gender", "male" },
            { "birthday_date", birthdayDate },
            { "description", "description" },
            { "city", "Kraków" },
            { "source", "api" },
            { "date_created", dateCreated },
            { "date_updated", dateUpdated }
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetContact().Execute();

        Assert.AreEqual("5A5359173738303F2F95B7E2", result.Id);
        Assert.AreEqual("Jan", result.FirstName);
        Assert.AreEqual("Kowalski", result.LastName);
        Assert.AreEqual("48500100100", result.PhoneNumber);
        Assert.AreEqual("jan@example.com", result.Email);
        Assert.AreEqual("male", result.Gender);
        Assert.AreEqual(DateTime.Parse(birthdayDate), result.BirthdayDate);
        Assert.AreEqual(DateTime.Parse(dateCreated), result.DateCreated);
        Assert.AreEqual(DateTime.Parse(dateUpdated), result.DateUpdated);
    }

    [TestMethod]
    public void get_contact_without_optional_dates()
    {
        var response = new Dictionary<string, dynamic>
        {
            { "id", "5A5359173738303F2F95B7E2" },
            { "phone_number", "48500100100" },
            { "birthday_date", null },
            { "date_created", "2024-11-26T14:20:53+01:00" },
            { "date_updated", null }
        };
        _proxyStub.SyncExecutionResponse = new HttpResponseEntity(
            response.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetContact().Execute();

        Assert.AreEqual("5A5359173738303F2F95B7E2", result.Id);
        Assert.IsNull(result.BirthdayDate);
        Assert.IsNull(result.DateUpdated);
    }

    private GetContact GetContact()
    {
        var action = new GetContact("5A5359173738303F2F95B7E2");
        action.Proxy(_proxyStub);

        return action;
    }
}
