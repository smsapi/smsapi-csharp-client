using SMSApi.Api;

namespace smsapi.Api.Response.REST.Exception;

public class AccessForbiddenException : ClientException
{
    public AccessForbiddenException() : base("Access forbidden", 403)
    {
    }
}
