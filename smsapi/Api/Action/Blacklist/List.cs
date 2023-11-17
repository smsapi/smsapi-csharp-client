using SMSApi.Api.Response;

namespace SMSApi.Api.Action.Blacklist;

public class List : Action<BasicCollection<BlacklistRecord>>, IPaginable
{
    protected override RequestMethod Method => RequestMethod.GET;
    
    protected override string Uri() => "blacklist/phone_numbers";

    protected override ApiType ApiType() => Action.ApiType.Rest;
    
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}
