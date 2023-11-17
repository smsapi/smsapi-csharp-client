using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action.Blacklist;

public class Add : Action<BlacklistRecord>
{
    private readonly string phoneNumber;
    private DateTimeOffset? withExpireAt;

    public Add(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }

    protected override RequestMethod Method => RequestMethod.POST;

    public int? Limit { get; set; }
    public int? Offset { get; set; }

    public Add WithExpireAt(DateTimeOffset expireAt)
    {
        withExpireAt = expireAt;

        return this;
    }

    public Add WithExpireAt(long expireAtTimestampSeconds)
    {
        withExpireAt = DateTimeOffset.FromUnixTimeSeconds(expireAtTimestampSeconds);

        return this;
    }

    protected override string Uri()
    {
        return "blacklist/phone_numbers";
    }

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override NameValueCollection Values()
    {
        var values = new NameValueCollection { { "phone_number", phoneNumber } };
        
        if (withExpireAt != null)
            values.Add("expire_at", withExpireAt.Value.ToString("O"));
        
        return values;
    }
}
