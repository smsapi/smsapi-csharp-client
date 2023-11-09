namespace SMSApi.Api;

public class Features
{
    internal readonly IClient Client;
    internal readonly Proxy Proxy;

    public Features(IClient client, ProxyAddress proxy = ProxyAddress.SmsApiIo)
    {
        Proxy = new ProxyHTTP(proxy.GetUrl());
        Client = client;
    }
    
    public Features(IClient client, Proxy proxy)
    {
        Proxy = proxy;
        Client = client;
    }
}
