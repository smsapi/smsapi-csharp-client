using SMSApi.Api.Response.ShortUrl;

namespace SMSApi.Api.Action.ShortUrl;

public sealed class DeleteShortUrl : Action<ShortLinkRemovalResult>
{
    private readonly string _id;

    public DeleteShortUrl(string id)
    {
        _id = id;
    }

    protected override RequestMethod Method => RequestMethod.DELETE;

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return $"short_url/links/{_id}";
    }
}
