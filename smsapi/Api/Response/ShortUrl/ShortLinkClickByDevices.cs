using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.ShortUrl;

public readonly record struct ShortLinkClickByDevices : IResponseCodeAwareResolver
{
    public readonly ShortLinkDevicesClickCount Clicks;
    public readonly string LinkId;
}

public readonly record struct ShortLinkDevicesClickCount
{
    public readonly int Android;
    public readonly int Ios;
    public readonly int Other;
    public readonly int Sum;
    public readonly int Wp;
}
