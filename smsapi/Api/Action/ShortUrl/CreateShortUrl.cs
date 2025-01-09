using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization;
using SMSApi.Api.Response.ShortUrl;

namespace SMSApi.Api.Action.ShortUrl;

public sealed class CreateShortUrl : Action<ShortLink>
{
    public enum ShortUrlExpirationUnit
    {
        [EnumMember(Value = "seconds")] Seconds,

        [EnumMember(Value = "minutes")] Minutes,

        [EnumMember(Value = "hours")] Hours,

        [EnumMember(Value = "days")] Days
    }

    private string? _description;
    private (uint, string)? _expireAt;
    private readonly FileInfo? _file;

    private readonly string _name;
    private readonly string? _url;

    public CreateShortUrl(string name, string url)
    {
        _name = name;
        _url = url;
    }

    public CreateShortUrl(string name, FileInfo file)
    {
        _name = name;
        _file = file;
    }

    protected override RequestMethod Method => RequestMethod.POST;
    protected override ActionContentType ContentType => ActionContentType.FormWww;

    public CreateShortUrl WithExpiration(uint expireIn, ShortUrlExpirationUnit expirationUnit)
    {
        _expireAt = (expireIn, expirationUnit.GetEnumValue());

        return this;
    }

    public CreateShortUrl WithDescription(string description)
    {
        _description = description;

        return this;
    }

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return "short_url/links";
    }

    protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
    {
        var body = new HashSet<KeyValuePair<string, dynamic?>>
        {
            KeyValuePair.Create<string, dynamic>("name", _name)
        };

        _url?.Let(url => body.Add(("url", url)));

        _description?.Let(description => body.Add(("description", description)));

        _expireAt?.Let(expiration =>
        {
            body.Add(
                ("expire_time", expiration.Item1),
                ("expire_unit", expiration.Item2)
            );
        });

        _file?.Let(_ => body.Add(("type", "FILE")));

        return (new NameValueCollection(), body);
    }

    protected override Dictionary<string, Stream> Files()
    {
        var files = new Dictionary<string, Stream>();

        _file?.Let(file => files.Add(file.Name, file.OpenRead()));

        return files;
    }
}
