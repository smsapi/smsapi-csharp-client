
namespace SMSApi.Api
{
    public class ActionException : ApiException
    {
        public ActionException(string message, int code) : base(message, code) { }
    }
}
