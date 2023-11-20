using System.Runtime.Serialization;

namespace SMSApi.Api.Response.Common.Telephony;

[DataContract]
public readonly record struct Country
{
    [DataMember(Name = "name")] public readonly string Name;
    [DataMember(Name = "mcc")] public readonly int MCC;

    public Country(string name, int mcc)
    {
        Name = name;
        MCC = mcc;
    }
}
