using System.Collections.Generic;
using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Ping;

[DataContract]
public readonly record struct PingServiceResponse : IResponseCodeAwareResolver
{
    [DataMember(Name = "authorized")] public readonly bool Authorized;

    [DataMember(Name = "unavailable")] public readonly IEnumerable<string> UnavailableServices;
}
