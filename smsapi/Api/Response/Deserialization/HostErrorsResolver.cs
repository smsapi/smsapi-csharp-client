using System;
using System.Collections.Generic;
using System.IO;
using SMSApi.Api.Response.ResponseResolver;
using smsapi.Api.Response.REST.Exception;

namespace SMSApi.Api.Response.Deserialization;

public class HostErrorsResolver : IResponseCodeAwareResolver
{
    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new Dictionary<int, Action<Stream>>
        {
            { 503, _ => throw new ServiceUnavailableException() },
        };
    }
}
