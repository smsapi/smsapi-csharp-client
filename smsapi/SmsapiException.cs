namespace SMSApi.Api
{
    public class SmsapiException : Exception
    {
        private readonly int _code;

        public SmsapiException(string message, int code) : base(message)
        {
            _code = code;
        }

        public int GetCode()
        {
            return _code;
        }
    }
}