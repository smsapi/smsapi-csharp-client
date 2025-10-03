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

    public CreateSendername Create(string sender)
    {
        var action = new CreateSendername(sender);
        action.Proxy(proxy);

        return action;
    }

    public GetSendername Get(string sender)
    {
        var action = new GetSendername(sender);
        action.Proxy(proxy);

        return action;
    }

    public DeleteSendername Delete(string sender)
    {
        var action = new DeleteSendername(sender);
        action.Proxy(proxy);

        return action;
    }

    public ChangeDefaultSendername ChangeDefault(string sender)
    {
        var action = new ChangeDefaultSendername(sender);
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
