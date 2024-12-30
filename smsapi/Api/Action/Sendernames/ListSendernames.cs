using SMSApi.Api.Response;
using SMSApi.Api.Response.Sendernames;

namespace SMSApi.Api.Action.Sendernames;

public sealed class ListSendernames : Action<BasicCollection<Sendername>>, IPaginable
{
    public uint? Limit { get; set; }
    public uint? Offset { get; set; }

    protected override RequestMethod Method => RequestMethod.GET;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return "sms/sendernames";
    }
}
