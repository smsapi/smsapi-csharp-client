using System;
using System.Collections.Generic;
using System.IO;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.MFA;

public class MFAVerificationResponse : IResponseCodeAwareResolver
{
    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new Dictionary<int, Action<Stream>>
        {
            { 404, _ => throw new InvalidVerificationCodeException() },
            { 408, _ => throw new ExpiredVerificationCode() },
        };
    }

    public class InvalidVerificationCodeException : ClientException
    {
        public InvalidVerificationCodeException() : base("Invalid verification code", 404)
        {
        }
    }
    
    public class ExpiredVerificationCode : ClientException
    {
        public ExpiredVerificationCode() : base("Verification code has expired", 408)
        {
        }
    }
}
