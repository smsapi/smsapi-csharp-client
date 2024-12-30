using System;

namespace SMSApi.Api.Response.Sendernames;

public readonly record struct Sendername
{
    public readonly DateTime CreatedAt;

    public readonly bool IsDefault;

    public readonly string Sender;

    public readonly string Status;
}
