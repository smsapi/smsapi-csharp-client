
namespace SMSApi.Api
{
    public class HostException : SMSApi.Api.Exception
    {
        public static const int E_JSON_DECODE = -1;

        private int Code;

        public HostException(string message, int code)
            : base(message)
        {
            Code = code;
        }
    }
}
