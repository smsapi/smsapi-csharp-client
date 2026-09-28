using System;

namespace SMSApi.Api
{
    public class SmsapiException : Exception
    {
        protected SmsapiException(string message, string code) : base(message)
        {
            Code = code;
        }

        protected SmsapiException(string message, string code, string response, Exception innerException = null)
            : base(message, innerException)
        {
            Code = code;
            Response = response;
        }

        public string Code { get; private set; }
        
        public string Response { get; private set; }
    }
}
