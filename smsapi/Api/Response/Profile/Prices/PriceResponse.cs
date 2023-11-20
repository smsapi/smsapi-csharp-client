using System.Runtime.Serialization;
using SMSApi.Api.Response.Common.Telephony;

namespace SMSApi.Api.Response.Profile.Prices;

[DataContract]
public readonly struct PriceResponse
{
    [DataMember(Name = "price")] public readonly Price Price;
    
    [DataMember(Name = "country")] public readonly Country Country;
    
    [DataMember(Name = "network")] public readonly Network Network;
    
    [DataMember(Name = "type")] public readonly string Type;
}

[DataContract]
public readonly struct Price
{
    [DataMember(Name = "amount")] public readonly float Amount;
    [DataMember(Name = "currency")] public readonly string Currency;
}
