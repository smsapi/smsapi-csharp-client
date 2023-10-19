using System;

namespace SMSApi.Api
{
    public class ClientException : SmsapiException
    {
        public ClientException(string message, int code)
            : base(message, Convert.ToString(code))
        { }
    }
}
