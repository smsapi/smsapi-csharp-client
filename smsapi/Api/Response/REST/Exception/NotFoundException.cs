using SMSApi.Api;

namespace smsapi.Api.Response.REST.Exception;

public class NotFoundException : ClientException
{
    public NotFoundException() : base("Not found", 404)
    {
    }
}
