using System;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Sendernames;

public readonly record struct Sendername : IResponseCodeAwareResolver
{
    public readonly DateTime CreatedAt;

    public readonly bool IsDefault;

    public readonly string Sender;

    public readonly string Status;
}
