using SMSApi.Api.Response;
using SMSApi.Api.Response.HLR;

namespace SMSApi.Api.Action;

public class ListLookups : Action<BasicCollection<LookupResult>>, IPaginable
{
    protected override RequestMethod Method => RequestMethod.GET;
    
    protected override string Uri() => "hlr/lookups";
    
    public uint? Limit { get; set; }
    public uint? Offset { get; set; }
}
