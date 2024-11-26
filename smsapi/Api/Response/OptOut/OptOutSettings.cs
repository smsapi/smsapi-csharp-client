using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.OptOut;

[DataContract]
public record struct OptOutSettings : IResponseCodeAwareResolver
{
    [DataMember(Name = "brand")] public readonly string Brand;
}
