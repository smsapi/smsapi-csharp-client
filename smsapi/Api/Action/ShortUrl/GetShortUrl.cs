using SMSApi.Api.Response.ShortUrl;

namespace SMSApi.Api.Action.ShortUrl;

public sealed class GetShortUrl : Action<ShortLink>
{
    private readonly string _id;

    public GetShortUrl(string id)
    {
        _id = id;
    }

    protected override RequestMethod Method => RequestMethod.GET;

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return $"short_url/links/{_id}";
    }
}
