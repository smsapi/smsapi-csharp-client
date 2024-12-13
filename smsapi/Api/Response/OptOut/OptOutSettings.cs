using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.OptOut;

public sealed class OptOutSettings : IResponseCodeAwareResolver
{
    public readonly string Brand;
}
