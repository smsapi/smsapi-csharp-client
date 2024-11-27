using SMSApi.Api.Action.OptOut;

namespace SMSApi.Api;

public class OptOutFactory : Factory
{
    public OptOutFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(address)
    {
    }

    public OptOutFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(client, address)
    {
    }

    public OptOutFactory(IClient client, Proxy proxy)
        : base(client, proxy)
    {
    }

    public DeleteOptOut DeleteOptOut(string optOutId)
    {
        var action = new DeleteOptOut(optOutId);
        action.Proxy(proxy);

        return action;
    }
    
    public OptOutList List()
    {
        var action = new OptOutList();
        action.Proxy(proxy);

        return action;
    }
    
    public GetOptOutSettings Settings()
    {
        var action = new GetOptOutSettings();
        action.Proxy(proxy);

        return action;
    }
}

public static class OptOutFeatureRegister
{
    public static OptOutFactory OptOut(this Features features)
    {
        return new OptOutFactory(features.Client, features.Proxy);
    }
}
