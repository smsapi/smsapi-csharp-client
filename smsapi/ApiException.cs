
namespace SMSApi.Api
{
    public class ApiException : System.Exception
    {
        private int Code;

        public ApiException(string message, int code)
            : base(message) 
        {
            Code = code;
        }
    }
}
