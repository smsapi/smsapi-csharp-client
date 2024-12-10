using System;
using Newtonsoft.Json;

namespace SMSApi.Api.Response.ShortUrl;

public readonly record struct ShortLink
{
    public readonly string Id;

    public readonly string Name;

    public readonly string Url;
    
    public readonly string ShortUrl;
    

    [JsonProperty("filename")]
    public readonly string? FileName;
    
    public readonly string Type;
    
    [JsonProperty("expire")]
    public readonly DateTime ExpireAt;

    public readonly int Hits;
    
    [JsonProperty("hits_unique")]
    public readonly int UniqueHits;
    
    public readonly string Description;
}
