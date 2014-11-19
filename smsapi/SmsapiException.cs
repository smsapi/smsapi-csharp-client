using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSApi.Api
{
    public class SmsapiException : SMSApi.Api.Exception
    {
        private int Code;

        public SmsapiException(string message, int code)
            : base(message)
        {
            Code = code;
        }

        public int GetCode()
        {
            return Code;
        }
    }
}
