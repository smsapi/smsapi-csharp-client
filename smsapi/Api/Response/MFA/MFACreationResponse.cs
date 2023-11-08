using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.MFA;

[DataContract]
public class MFACreationResponse : IResponseCodeAwareResolver
{
    [DataMember(Name = "code")] public readonly string Code;

    [DataMember(Name = "from")] public readonly string From;

    [DataMember(Name = "id")] public readonly string Id;

    [DataMember(Name = "phone_number")] public readonly string PhoneNumber;
}
