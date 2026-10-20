using smsapi.Api.Response.REST.Exception;

namespace SMSApi.Api.Response.OptOut.Exception;

public class OptOutNotFoundException : NotFoundException
{
    public OptOutNotFoundException() : base("Opt-out not found")
    {
    }
}
