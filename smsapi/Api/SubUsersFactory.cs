using SMSApi.Api.Action.Subusers;
using SMSApi.Api.Action.Subusers.Creation;

namespace SMSApi.Api;

public class SubUsersFactory : Factory
{
    public SubUsersFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(address)
    {
    }

    public SubUsersFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(client, address)
    {
    }

    public SubUsersFactory(IClient client, Proxy proxy)
        : base(client, proxy)
    {
    }

    public List List()
    {
        var action = new List();
        
        action.Proxy(proxy);

        return action;
    }

    public CreateSubuser Create(SubuserCredentials credentials)
    {
        var action = new CreateSubuser(credentials);

        action.Proxy(proxy);

        return action;
    }
}

public static class SubusersFeatureRegister
{
    public static SubUsersFactory Subusers(this Features features)
    {
        return new SubUsersFactory(features.Client, features.Proxy);
    }
}
