using SMSApi.Api;

namespace smsapi.Api.Response.REST.Exception;

public class TooManyRequestsException : ClientException
{
    public TooManyRequestsException() : base("Too many requests", 429)
    {
    }
}
