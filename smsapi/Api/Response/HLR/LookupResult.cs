using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SMSApi.Api.Response.Common.Telephony;

namespace SMSApi.Api.Response.HLR;

public record struct LookupResult
{
    public readonly double Cost;
    
    public readonly Country? Country;

    public readonly uint? ErrorCode;
    public readonly string Id;

    public readonly string Interface;

    public readonly Network? Network;

    public readonly string PhoneNumber;

    public readonly Ported? Ported;

    public readonly DateTime SentAt;
}

public readonly record struct Ported
{
    [JsonProperty("ported")] public readonly IEnumerable<MCC> PortedFrom;

    public Ported(IEnumerable<MCC> portedFrom)
    {
        PortedFrom = portedFrom;
    }
}

public readonly record struct MCC
{
    public readonly int Mcc;

    public MCC(int mcc)
    {
        Mcc = mcc;
    }
}