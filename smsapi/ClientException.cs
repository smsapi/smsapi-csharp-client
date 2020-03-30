
namespace SMSApi.Api
{
    public class ClientException : SMSApi.Api.SmsapiException
    {
        public ClientException(string message, string code)
            : base(message, code)
        {
        }
    }
}
