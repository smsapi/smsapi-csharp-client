using System;
using System.Collections.Generic;
using System.IO;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Deserialization;

public class TooManyRequestsErrorResolver : IResponseCodeAwareResolver
{
    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new Dictionary<int, Action<Stream>>
        {
            { 429, _ => throw new TooManyRequestsException() }
        };
    }

    public class TooManyRequestsException : ClientException
    {
        public TooManyRequestsException() : base("Too many requests", 429)
        {
        }
    }
}
