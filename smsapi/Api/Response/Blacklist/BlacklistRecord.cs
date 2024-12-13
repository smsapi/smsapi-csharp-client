using System;
using Newtonsoft.Json;
using SMSApi.Api.Response.ResponseResolver;

namespace smsapi.Api.Response.Blacklist;

public record struct BlacklistRecord : IResponseCodeAwareResolver
{
    public readonly string Id;

    public readonly string PhoneNumber;

    [JsonProperty("created_at")] public readonly DateTime DateCreated;

    [JsonProperty("expire_at")] public readonly DateTime? DateExpired;
}
