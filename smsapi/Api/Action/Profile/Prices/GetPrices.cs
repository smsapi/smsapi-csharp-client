using SMSApi.Api.Response;
using SMSApi.Api.Response.Profile.Prices;

namespace SMSApi.Api.Action.Profile.Prices;

public class GetPrices : Action<BasicCollection<PriceResponse>>
{
    protected override RequestMethod Method => RequestMethod.GET;
    
    protected override string Uri() => "profile/prices";

    protected override ApiType ApiType() => Action.ApiType.Rest;
}
