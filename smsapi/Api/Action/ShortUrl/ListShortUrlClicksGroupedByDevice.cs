using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response;
using SMSApi.Api.Response.ShortUrl;

namespace SMSApi.Api.Action.ShortUrl;

public sealed class ListShortUrlClicksGroupedByDevice : Action<BasicCollection<ShortLinkClickByDevices>>
{
    private readonly string[] _ids;

    public ListShortUrlClicksGroupedByDevice(params string[] ids)
    {
        if (ids.Length == 0)
            throw new ArgumentException("Invalid ids count, at least one is required.");

        _ids = ids;
    }

    protected override RequestMethod Method => RequestMethod.GET;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return "short_url/clicks_by_mobile_device";
    }

    protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
    {
        return (
            new NameValueCollection(),
            new HashSet<KeyValuePair<string, dynamic?>>
            {
                KeyValuePair.Create<string, dynamic?>("links", _ids),
            }
        );
    }
}
