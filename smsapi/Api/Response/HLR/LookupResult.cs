using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SMSApi.Api.Response.Common.Telephony;

namespace SMSApi.Api.Response.HLR;

[DataContract]
public class LookupResult
{
    [DataMember(Name = "id")] public readonly string Id;
    
    [DataMember(Name = "phone_number")] public readonly string PhoneNumber;
    
    [DataMember(Name = "interface")] public readonly string Interface;
    
    [DataMember(Name = "country")] public readonly Country? Country;
    
    [DataMember(Name = "network")] public readonly Network? Network;
    
    [DataMember(Name = "cost")] public readonly LookupCost Cost;
    
    [DataMember(Name = "ported")] public readonly Ported? Ported;
    
    [DataMember(Name = "error_code")] public readonly uint? ErrorCode;

    public DateTime SentAt;
    
    [DataMember(Name = "sent_at")] 
    private string? SentAtDeserializer
    {
        set => SentAt = DateTime.Parse(value);
        get => default;
    }
}

[DataContract]
public readonly record struct LookupCost
{
    [DataMember(Name = "points")] public readonly double Points;

    public LookupCost(double points)
    {
        Points = points;
    }
}

[DataContract]
public readonly record struct Ported
{
    [DataMember(Name = "ported")] public readonly IEnumerable<MCC> PortedFrom;

    public Ported(IEnumerable<MCC> portedFrom)
    {
        PortedFrom = portedFrom;
    }
}

[DataContract]
public readonly record struct MCC
{
    [DataMember(Name = "mcc")] public readonly int Mcc;

    public MCC(int mcc)
    {
        Mcc = mcc;
    }
}
