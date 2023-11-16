using System;
using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response;

[DataContract]
public record struct BlacklistRecord : IResponseCodeAwareResolver
{
    [DataMember(Name = "id")] public readonly string Id;
    
    [DataMember(Name = "phone_number")] public readonly string PhoneNumber;

    public DateTime DateCreated;
    
    public DateTime? DateExpired;
    
    [DataMember(Name = "created_at")] 
    private string DateCreatedDeserializer
    {
        set => DateCreated = DateTime.Parse(value);
        get => default;
    }
    
    [DataMember(Name = "expire_at")] 
    private string? DateExpiredDeserializer
    {
        set => DateExpired = value != null ? DateTime.Parse(value) : null;
        get => default;
    }
}
