using SMSApi.Api.Response;
using SMSApi.Api.Response.Subusers;

namespace SMSApi.Api.Action.Subusers;

public class List : Action<BasicCollection<SubuserDetails>>, IPaginable
{
    protected override RequestMethod Method => RequestMethod.GET;
    protected override string Uri() => "subusers";

    protected override ApiType ApiType() => Action.ApiType.Rest;

    public uint? Limit { get; set; }
    public uint? Offset { get; set; }
}
