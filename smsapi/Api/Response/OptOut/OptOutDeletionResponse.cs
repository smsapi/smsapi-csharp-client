using System;
using System.Collections.Generic;
using System.IO;
using SMSApi.Api.Response.OptOut.Exception;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.OptOut;

public class OptOutDeletionResponse : IResponseCodeAwareResolver
{
    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new Dictionary<int, Action<Stream>>
        {
            { 404, _ => throw new OptOutNotFoundException() },
        };
    }
}
