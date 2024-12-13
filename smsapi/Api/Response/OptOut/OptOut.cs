using System;

namespace SMSApi.Api.Response.OptOut;

public sealed class OptOut
{
    public readonly string Id;
    
    public readonly string PhoneNumber;

    public readonly DateTime CreationTime;
}
