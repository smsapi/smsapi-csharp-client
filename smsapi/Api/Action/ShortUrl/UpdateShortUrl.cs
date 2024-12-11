using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response.ShortUrl;

namespace SMSApi.Api.Action.ShortUrl;

public sealed class UpdateShortUrl : Action<ShortLink>
{
    private readonly string _id;
    private string? _url;
    private string? _name;
    private string? _description;

    public UpdateShortUrl(string id)
    {
        _id = id;
    }

    public UpdateShortUrl ChangeUrl(string url)
    {
        _url = url;

        return this;
    }

    public UpdateShortUrl ChangeName(string name)
    {
        _name = name;

        return this;
    }

    public UpdateShortUrl ChangeDescription(string description)
    {
        _description = description;

        return this;
    }

    protected override RequestMethod Method => RequestMethod.PUT;

    protected override ActionContentType ContentType => ActionContentType.Json;

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return $"short_url/links/{_id}";
    }

    protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
    {
        var values = new HashSet<KeyValuePair<string, dynamic?>>();

        _url?.Let(url => values.Add(("url", url)));

        _name?.Let(name => values.Add(("name", name)));

        _description?.Let(description => values.Add(("description", description)));

        return (new NameValueCollection(), values);
    }
}
