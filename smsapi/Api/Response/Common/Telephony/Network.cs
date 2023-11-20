using System.Runtime.Serialization;

namespace SMSApi.Api.Response.Common.Telephony;

[DataContract]
public readonly record struct Network
{
    [DataMember(Name = "name")] public readonly string Name;
    [DataMember(Name = "mnc")] public readonly int MNC;

    public Network(string name, int mnc)
    {
        Name = name;
        MNC = mnc;
    }
}
