using System.IO;
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

    public CreateShortUrl Create(string name, string uri)
    {
        var action = new CreateShortUrl(name, uri);
        action.Proxy(proxy);

        return action;
    }

    public CreateShortUrl Create(string name, Stream file)
    {
        var action = new CreateShortUrl(name, file);
        action.Proxy(proxy);

        return action;
    }

    public GetShortUrl GetShortUrl(string id)
    {
        var action = new GetShortUrl(id);
        action.Proxy(proxy);

        return action;
    }

    public UpdateShortUrl UpdateShortUrl(string id)
    {
        var action = new UpdateShortUrl(id);
        action.Proxy(proxy);

        return action;
    }

    public DeleteShortUrl DeleteShortUrl(string id)
    {
        var action = new DeleteShortUrl(id);
        action.Proxy(proxy);

        return action;
    }

    public ListShortUrlClicks ListClicks()
    {
        var action = new ListShortUrlClicks();
        action.Proxy(proxy);

        return action;
    }

    public ListShortUrlClicksGroupedByDevice ListClicksGroupedByDeviceType(params string[] linkId)
    {
        var action = new ListShortUrlClicksGroupedByDevice(linkId);
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
