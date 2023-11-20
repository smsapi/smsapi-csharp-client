using SMSApi.Api.Response;
using SMSApi.Api.Response.HLR;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Action;

public class ListLookups : Action<BasicCollection<LookupResult>>, IPaginable, IResponseCodeAwareResolver
{
    protected override RequestMethod Method => RequestMethod.GET;
    
    protected override string Uri() => "hlr/lookups";

    protected override ApiType ApiType() => Action.ApiType.Rest;

    public uint? Limit { get; set; }
    public uint? Offset { get; set; }
}
