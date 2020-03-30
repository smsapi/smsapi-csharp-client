
namespace SMSApi.Api
{
    public class ActionException : SMSApi.Api.SmsapiException
    {
        public ActionException(string message, string code)
            : base(message, code)
        {
        }
    }
}
