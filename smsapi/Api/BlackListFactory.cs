using SMSApi.Api.Action.Blacklist;

namespace SMSApi.Api;

public class BlackListFactory : Factory
{
    public BlackListFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo) : base(client, address)
    {
    }

    public BlackListFactory(IClient client, Proxy proxy) : base(client, proxy)
    {
    }

    public List List()
    {
        var service = new List();
        service.Proxy(proxy);

        return service;
    }
    
    public Add Add(string phoneNumber)
    {
        var service = new Add(phoneNumber);
        service.Proxy(proxy);

        return service;
    }
    
    public Remove Remove(string id)
    {
        var service = new Remove(id);
        service.Proxy(proxy);

        return service;
    }
}

public static class BlacklistFeatureRegister
{
    public static BlackListFactory Blacklist(this Features features)
    {
        return new BlackListFactory(features.Client, features.Proxy);
    }
}
