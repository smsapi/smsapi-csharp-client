using SMSApi.Api;

namespace smsapi.Api.Response.REST.Exception;

public class UnhandledRestException : HostException
{
    public UnhandledRestException(string message, string code) : base(message, code)
    {
    }
}
