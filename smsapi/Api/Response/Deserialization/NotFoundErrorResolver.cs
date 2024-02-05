using System;
using System.Collections.Generic;
using System.IO;
using SMSApi.Api.Response.ResponseResolver;
using smsapi.Api.Response.REST.Exception;

namespace SMSApi.Api.Response.Deserialization;

public class NotFoundErrorResolver : IResponseCodeAwareResolver
{
    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new Dictionary<int, Action<Stream>>
        {
            { 404, _ => throw new NotFoundException() },
        };
    }
}
