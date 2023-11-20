using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using SMSApi.Api.Response.MFA.Exception;
using SMSApi.Api.Response.ResponseResolver;

namespace smsapi.Api.Response.Blacklist.Exception;

[DataContract]
public class BlacklistRemovalResult : IResponseCodeAwareResolver
{
    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new Dictionary<int, Action<Stream>>
        {
            { 404, _ => throw new BlacklistRecordDoesNotExistException() }
        };
    }
}
