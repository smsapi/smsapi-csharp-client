using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSApi.Api
{
    public class SmsapiException : SMSApi.Api.Exception
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
