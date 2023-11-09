using System;
using System.Collections.Generic;
using System.IO;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Deserialization;

public class AccessErrorResolver : IResponseCodeAwareResolver
{
    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new Dictionary<int, Action<Stream>>
        {
            { 401, _ => throw new UnauthorizedException() },
            { 403, _ => throw new AccessForbiddenException() }
        };
    }

    public class UnauthorizedException : ClientException
    {
        public UnauthorizedException() : base("Invalid credentials", 401)
        {
        }
    }

    public class AccessForbiddenException : ClientException
    {
        public AccessForbiddenException() : base("Access forbidden", 403)
        {
        }
    }
}
