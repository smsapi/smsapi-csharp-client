using System;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.ShortUrl;

public readonly record struct ShortLinkClick : IResponseCodeAwareResolver
{
    public readonly string Browser;

    public readonly DateTime DateHit;

    public readonly string Device;

    public readonly string Name;

    public readonly string Os;

    public readonly string PhoneNumber;

    public readonly string ShortUrl;
}
