using System;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response.OptOut;

[DataContract]
public class OptOut
{
    [DataMember(Name = "id")] public readonly string Id;
    
    [DataMember(Name = "phone_number")] public readonly string PhoneNumber;
    
    public DateTime CreationTime { get; private set; }
    
    [DataMember(Name = "creation_time")] 
    private string CreationTimeSerializer
    {
        set => CreationTime = DateTime.Parse(value);
        get => default!;
    }
}
