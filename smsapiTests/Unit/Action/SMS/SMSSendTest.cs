using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action;

namespace smsapiTests.Unit.SMS;

[TestClass]
public class SMSSendTest : UnitTestBase<SMSSend>
{
    private const string DateFormat = "yyyy-MM-ddTHH:mm:ssK";

    private static readonly DateTime DateTime = DateTime.Now;
    
    private readonly ProxyAssert _proxyAssert;

    public SMSSendTest()
    {
        _proxyAssert = new ProxyAssert(SpyProxy);
    }


    [TestMethod]
    public void action_has_proper_uri()
    {
        var action = CreateAction();

        Execute(action);

        var expectedUri = "sms.do";
        Assert.IsTrue(SpyProxy.RequestedUri.Equals(expectedUri));
    }

    [TestMethod]
    [DataRow("single", "0")]
    [DataRow("nounicode", "0")]
    [DataRow("flash", "0")]
    [DataRow("fast", "0")]
    [DataRow("details", "1")]
    public void action_has_parameters_set_by_default(string expectedName, string expectedValue)
    {
        var action = CreateAction();

        Execute(action);

        _proxyAssert.AssertParametersContain(expectedName, expectedValue);
    }

    [TestMethod]
    [DataRow("SetSingle", new object[] { true }, "single", "1")]
    [DataRow("SetSingle", new object[] { false }, "single", "0")]
    [DataRow("SetDataCoding", new object[] { "gsm" }, "datacoding", "gsm")]
    [DataRow("SetFast", new object[] { true }, "fast", "1")]
    [DataRow("SetFast", new object[] { false }, "fast", "0")]
    [DataRow("SetFlash", new object[] { true }, "flash", "1")]
    [DataRow("SetFlash", new object[] { false }, "flash", "0")]
    [DataRow("SetGroup", new object[] { "any group" }, "group", "any group")]
    [DataRow("SetNormalize", new object[] { true }, "normalize", "1")]
    [DataRow("SetNoUnicode", new object[] { false }, "nounicode", "0")]
    [DataRow("SetPartner", new object[] { "partner id" }, "partner_id", "partner id")]
    [DataRow("SetSingle", new object[] { true }, "single", "1")]
    [DataRow("SetTest", new object[] { true }, "test", "1")]
    [DataRow("SetText", new object[] { "fancy message" }, "message", "fancy message")]
    [DataRow("SetTemplate", new object[] { "template name" }, "template", "template name")]
    [DynamicData(nameof(ExpirationDate), DynamicDataSourceType.Method)]
    [DynamicData(nameof(SendDate), DynamicDataSourceType.Method)]
    [DynamicData(nameof(SetTo), DynamicDataSourceType.Method)]
    public void action_has_proper_parameters_binded(string methodName, object[] methodArgument,
        string expectedParameterName, string expectedParameterValue, Type argumentType = null)
    {
        var action = CreateAction();
        GetActionMethod(action, methodName, argumentType).Invoke(action, methodArgument);

        Execute(action);

        _proxyAssert.AssertParametersContain(expectedParameterName, expectedParameterValue);
    }

    protected override SMSSend CreateAction()
    {
        var action = base.CreateAction();
        AddNecessaryParameters(action);

        return action;
    }

    private static void AddNecessaryParameters(SMSSend action)
    {
        action.SetText("any");
        action.SetTo("any");
    }

    private MethodInfo GetActionMethod(SMSSend action, string methodName, Type argumentType = null)
    {
        if (argumentType != null) return action.GetType().GetMethod(methodName, new[] { argumentType });

        return action.GetType().GetMethod(methodName);
    }

    private static IEnumerable<object[]> ExpirationDate()
    {
        return new[]
        {
            new object[]
                { "SetDateExpire", new object[] { "2000-01-01" }, "expiration_date", "2000-01-01", typeof(string) },
            new object[]
            {
                "SetDateExpire", new object[] { DateTime }, "expiration_date", DateTime.ToString(DateFormat),
                typeof(DateTime)
            }
        };
    }

    private static IEnumerable<object[]> SendDate()
    {
        return new[]
        {
            new object[] { "SetDateSent", new object[] { "2000-01-01" }, "date", "2000-01-01", typeof(string) },
            new object[]
                { "SetDateSent", new object[] { DateTime }, "date", DateTime.ToString(DateFormat), typeof(DateTime) }
        };
    }

    private static IEnumerable<object[]> SetTo()
    {
        var recipients = new[] { "48500100100, 48600100100" };
        var expectedRecipientsString = string.Join(",", recipients);

        return new[]
        {
            new object[]
                { "SetTo", new object[] { expectedRecipientsString }, "to", expectedRecipientsString, typeof(string) },
            new object[]
                { "SetTo", new object[] { recipients }, "to", expectedRecipientsString, typeof(string[]) }
        };
    }
}