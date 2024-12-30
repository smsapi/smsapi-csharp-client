using SMSApi.Api.Action.Sendernames;

namespace SMSApi.Api;

public class SendernamesFactory : Factory
{
    public SendernamesFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(address)
    {
    }

    public SendernamesFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(client, address)
    {
    }

    public SendernamesFactory(IClient client, Proxy proxy)
        : base(client, proxy)
    {
    }

    public ListSendernames List()
    {
        var action = new ListSendernames();
        action.Proxy(proxy);

        return action;
    }
}

public static class SendernamesFeatureRegister
{
    public static SendernamesFactory Sendernames(this Features features)
    {
        return new SendernamesFactory(features.Client, features.Proxy);
    }
}
