using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Profile;

[DataContract]
public record struct Profile : IResponseCodeAwareResolver
{
    [DataMember(Name = "name")]
    public readonly string Name;
    
    [DataMember(Name = "username")]
    public readonly string Username;
    
    [DataMember(Name = "email")]
    public readonly string Email;
    
    [DataMember(Name = "phone_number")]
    public readonly string PhoneNumber;
    
    [DataMember(Name = "user_type")]
    public readonly string UserType;
    
    [DataMember(Name = "points")]
    public readonly double Points;
    
    [DataMember(Name = "payment_type")]
    public readonly string PaymentType;
}
