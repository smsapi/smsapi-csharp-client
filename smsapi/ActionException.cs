namespace SMSApi.Api
{
    public class ActionException : SmsapiException
    {
        public ActionException(string message, string code)
            : base(message, code)
        { }
    }
}
