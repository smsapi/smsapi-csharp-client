using System.Collections.Generic;
using Newtonsoft.Json;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Ping;

public sealed class PingServiceResponse : IResponseCodeAwareResolver
{
    public readonly bool Authorized;

    [JsonProperty("unavailable")] public readonly IEnumerable<string> UnavailableServices;
}
