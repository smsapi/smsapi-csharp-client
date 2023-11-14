using SMSApi.Api;

namespace smsapi.Api.Response.REST.Exception;

public class UnauthorizedException : ClientException
{
    public UnauthorizedException() : base("Invalid credentials", 401)
    {
    }
}
