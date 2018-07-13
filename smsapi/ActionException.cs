
namespace SMSApi.Api
{
    public class ActionException : SmsapiException
    {
        public ActionException(string message, int code)
            : base(message, code)
        {
        }
    }
}
