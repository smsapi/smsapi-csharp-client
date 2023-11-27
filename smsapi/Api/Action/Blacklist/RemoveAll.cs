using smsapi.Api.Response.Blacklist;

namespace SMSApi.Api.Action.Blacklist;

public sealed class RemoveAll : Action<BlacklistRemovalResult>
{
    protected override RequestMethod Method => RequestMethod.DELETE;

    protected override string Uri() => "blacklist/phone_numbers";

    protected override ApiType ApiType() => Action.ApiType.Rest;
}
