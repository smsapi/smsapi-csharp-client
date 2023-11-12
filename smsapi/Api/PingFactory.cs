using SMSApi.Api.Action.Ping;

namespace SMSApi.Api;

public class PingFactory : Factory
{
    public PingFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo) : base(client, address)
    {
    }

    public PingFactory(IClient client, Proxy proxy) : base(client, proxy)
    {
    }

    public PingService PingService()
    {
        var service = new PingService();
        service.Proxy(proxy);

        return service;
    }
}

public static class PingFeatureRegister
{
    public static PingFactory Ping(this Features features)
    {
        return new PingFactory(features.Client, features.Proxy);
    }
}
