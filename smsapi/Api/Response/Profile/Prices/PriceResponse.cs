using SMSApi.Api.Response.Common.Telephony;

namespace SMSApi.Api.Response.Profile.Prices;

public readonly struct PriceResponse
{
    public readonly Price Price;
    
    public readonly Country Country;
    
    public readonly Network Network;
    
    public readonly string Type;
}

public readonly struct Price
{
    public readonly float Amount;
    public readonly string Currency;
}
