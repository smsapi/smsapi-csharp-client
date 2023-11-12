using SMSApi.Api.Action.Profile.Prices;

namespace SMSApi.Api;

public class PricesFactory : Factory
{
    public PricesFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(address)
    {
    }

    public PricesFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(client, address)
    {
    }

    public PricesFactory(IClient client, Proxy proxy)
        : base(client, proxy)
    {
    }

    public GetPrices GetPrices()
    {
        var action = new GetPrices();
        action.Proxy(proxy);

        return action;
    }
}

public static class PricesFeatureRegister
{
    public static PricesFactory Prices(this Features features)
    {
        return new PricesFactory(features.Client, features.Proxy);
    }
}
