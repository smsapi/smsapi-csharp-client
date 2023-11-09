using System.Net;

namespace SMSApi.Api.Response;

public static class HttpCodesGroupHelper
{
    public static bool IsSuccessful(this HttpStatusCode statusCode)
    {
        var intRepresentation = (int)statusCode;

        return intRepresentation is >= 200 and <= 299;
    }
}
