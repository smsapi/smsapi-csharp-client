using SMSApi.Api;

namespace smsapi.Api.Response.REST.Exception;

public class ServiceUnavailableException : HostException
{
    public ServiceUnavailableException() : base("Service is temporary unavailable", "503")
    {
    }
}
