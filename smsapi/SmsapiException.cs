namespace SMSApi.Api
{
    public class SmsapiException : Exception
    {
        protected SmsapiException(string message, string code) : base(message)
        {
            Code = code;
        }

        public string Code { get; private set; }
    }
}
