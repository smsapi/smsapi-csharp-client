using SMSApi.Api.Action.ShortUrl;

namespace SMSApi.Api;

public class ShortUrlFactory : Factory
{
    public ShortUrlFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(address)
    {
    }

    public ShortUrlFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(client, address)
    {
    }

    public ShortUrlFactory(IClient client, Proxy proxy)
        : base(client, proxy)
    {
    }

    public ShortUrlList List()
    {
        var action = new ShortUrlList();
        action.Proxy(proxy);

        return action;
    }
}

public static class ShortUrlFeatureRegister
{
    public static ShortUrlFactory ShortUrl(this Features features)
    {
        return new ShortUrlFactory(features.Client, features.Proxy);
    }
}
