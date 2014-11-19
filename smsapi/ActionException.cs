
namespace SMSApi.Api
{
    public class ActionException : SMSApi.Api.SmsapiException
    {
        public ActionException(string message, int code)
            : base(message, code)
        {
        }
    }
}
