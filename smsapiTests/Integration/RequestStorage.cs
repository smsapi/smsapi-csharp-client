using System.Collections.Generic;

namespace smsapiTests.Integration;

public static class RequestStorage
{
    public static string AuthorizationHeader;
    public static string UserAgentHeader;
    public static string Path;
    public static Dictionary<string, string> FormParameters;
    public static string Method;
}
