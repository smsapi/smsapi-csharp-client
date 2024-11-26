namespace SMSApi.Api.Response.OptOut.Exception;

public class OptOutNotFoundException : ClientException
{
    public OptOutNotFoundException() : base("Opt-out not found", 404)
    {
    }
}
