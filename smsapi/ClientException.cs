
namespace SMSApi.Api
{
    public class ClientException : SMSApi.Api.SmsapiException
    {
        public ClientException(string message, int code)
            : base(message, code)
        {
        }
    }
}
