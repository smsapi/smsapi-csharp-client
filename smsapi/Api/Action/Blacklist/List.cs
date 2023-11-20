using SMSApi.Api.Response;
using smsapi.Api.Response.Blacklist;

namespace SMSApi.Api.Action.Blacklist;

public class List : Action<BasicCollection<BlacklistRecord>>, IPaginable
{
    protected override RequestMethod Method => RequestMethod.GET;
    
    protected override string Uri() => "blacklist/phone_numbers";

    protected override ApiType ApiType() => Action.ApiType.Rest;
    
    public uint? Limit { get; set; }
    public uint? Offset { get; set; }
}
