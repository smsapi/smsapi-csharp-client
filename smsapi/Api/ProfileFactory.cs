using SMSApi.Api.Action.Profile;

namespace SMSApi.Api;

public class ProfileFactory : Factory
{
    public ProfileFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(address)
    {
    }

    public ProfileFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(client, address)
    {
    }

    public ProfileFactory(IClient client, Proxy proxy)
        : base(client, proxy)
    {
    }

    public GetProfile GetProfile()
    {
        var action = new GetProfile();
        action.Proxy(proxy);

        return action;
    }
}

public static class ProfileFeatureRegister
{
    public static ProfileFactory Profile(this Features features)
    {
        return new ProfileFactory(features.Client, features.Proxy);
    }
}
