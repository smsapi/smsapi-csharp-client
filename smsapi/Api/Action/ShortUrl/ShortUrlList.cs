using SMSApi.Api.Response;
using SMSApi.Api.Response.ShortUrl;

namespace SMSApi.Api.Action.ShortUrl;

public sealed class ShortUrlList : Action<BasicCollection<ShortLink>>, IPaginable
{
    protected override RequestMethod Method => RequestMethod.GET;

    public uint? Limit { get; set; }
    public uint? Offset { get; set; }

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return "short_url/links";
    }
}
