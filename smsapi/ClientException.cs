
namespace SMSApi.Api
{
    public class ClientException : SMSApi.Api.Exception
    {
        private int Code;

        public ClientException(string message, int code)
            : base(message)
        {
            Code = code;
        }
    }
}
