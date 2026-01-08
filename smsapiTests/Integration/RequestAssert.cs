using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsapiTests.Integration;

public static class RequestAssert
{
    public static void AssertContainsAuthorizationHeader(string value)
    {
        var headerExists = RequestStorage
            .AuthorizationHeader
            .Equals(value);

        Assert.IsTrue(headerExists, $"Found: {RequestStorage.AuthorizationHeader}");
    }
    
    public static void AssertContainsUserAgentHeader(string value)
    {
        var headerExists = RequestStorage
            .UserAgentHeader
            .Equals(value);

        Assert.IsTrue(headerExists, $"Expected {value}, Found: {RequestStorage.UserAgentHeader}");
    }
    
    public static void AsserRawPath(string path)
    {
        Assert.IsNotNull(RequestStorage.Path, "Missing request path");

        var pathEquals = RequestStorage
            .RawPath
            .Equals(path);

        Assert.IsTrue(pathEquals, "Found: " + RequestStorage.RawPath);
    }

    public static void AssertContainsFormParameter(string name, string value)
    {
        var containsParameter = RequestStorage.FormParameters.ContainsKey(name);
        Assert.IsTrue(containsParameter, $"Request does not contains {name} parameter");

        var actualValue = RequestStorage.FormParameters[name];
        Assert.AreEqual(value, actualValue, $"Actual value: {actualValue} ({actualValue.GetType()})");
    }
}
