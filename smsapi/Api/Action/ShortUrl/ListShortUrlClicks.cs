using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response;
using SMSApi.Api.Response.ShortUrl;

namespace SMSApi.Api.Action.ShortUrl;

public sealed class ListShortUrlClicks : Action<BasicCollection<ShortLinkClick>>
{
    private DateTime? _listFrom;
    private DateTime? _listTo;

    protected override RequestMethod Method => RequestMethod.GET;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return "short_url/clicks";
    }

    public ListShortUrlClicks ListFrom(DateTime date)
    {
        _listFrom = date;

        return this;
    }

    public ListShortUrlClicks ListTo(DateTime date)
    {
        _listTo = date;

        return this;
    }

    protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
    {
        var values = new HashSet<KeyValuePair<string, dynamic>>();

        _listFrom?.Let(from => values.Add(("date_from", from.ToString("yyyy-MM-dd"))));

        _listTo?.Let(to => values.Add(("date_to", to.ToString("yyyy-MM-dd"))));

        return (new NameValueCollection(), values!);
    }
}
