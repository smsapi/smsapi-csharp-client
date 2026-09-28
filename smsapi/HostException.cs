using System;

namespace SMSApi.Api
{
    public class HostException : SmsapiException
    {
        public static readonly string E_JSON_DECODE = "-1";

        public HostException(string message, string code)
            : base(message, Convert.ToString(code))
        { }

        public HostException(string message, string code, string response, Exception innerException = null)
            : base(message, Convert.ToString(code), response, innerException)
        { }
    }
}
