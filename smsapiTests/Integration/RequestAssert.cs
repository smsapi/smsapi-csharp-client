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
    
    public static void AsserPath(string path)
    {
        var pathEquals = RequestStorage
            .Path
            .Equals(path);

        Assert.IsTrue(pathEquals);
    }
}
