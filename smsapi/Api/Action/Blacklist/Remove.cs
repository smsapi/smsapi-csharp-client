using System;
using smsapi.Api.Response.Blacklist;

namespace SMSApi.Api.Action.Blacklist;

public class Remove : Action<BlacklistRemovalResult>
{
    private readonly string _id;

    public Remove(string id)
    {
        _id = id;
    }

    protected override RequestMethod Method => RequestMethod.DELETE;

    protected override string Uri() => $"blacklist/phone_numbers/{_id}";

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(_id))
            throw new ArgumentException("Id cannot be empty");
    }
}
