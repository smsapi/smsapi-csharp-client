using SMSApi.Api;

namespace smsapi.Api.Response.REST.Exception;

public class NotFoundException : ClientException
{
    public NotFoundException() : this("Not found")
    {
    }

    protected NotFoundException(string message) : base(message, 404)
    {
    }
}
