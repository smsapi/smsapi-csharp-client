using System.Runtime.Serialization;

namespace SMSApi.Api.Response.Profile.Prices;

[DataContract]
public readonly struct PriceResponse
{
    [DataMember(Name = "price")] public readonly Price Price;
    
    [DataMember(Name = "country")] public readonly Country Country;
    
    [DataMember(Name = "network")] public readonly Network Network;
}

[DataContract]
public readonly struct Price
{
    [DataMember(Name = "amount")] public readonly float Amount;
    [DataMember(Name = "currency")] public readonly string Currency;
}

[DataContract]
public readonly struct Country
{
    [DataMember(Name = "name")] public readonly string Name;
    [DataMember(Name = "mcc")] public readonly int MCC;
}

[DataContract]
public readonly struct Network
{
    [DataMember(Name = "name")] public readonly string Name;
    [DataMember(Name = "mnc")] public readonly int MNC;
}
