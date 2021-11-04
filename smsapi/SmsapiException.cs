namespace SMSApi.Api
{
    public class SmsapiException : Exception
    {
        private string Code;

        public SmsapiException(string message, string code)
            : base(message)
        {
            Code = code;
        }

        public string GetCode()
        {
            return Code;
        }
    }
}
