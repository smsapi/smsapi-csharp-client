using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SMSApi.Api.Response.ResponseResolver;
using SMSApi.Api.Response.ShortUrl.Exception;

namespace SMSApi.Api.Response.ShortUrl;

public readonly record struct ShortLink: IResponseCodeAwareResolver
{
    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new()
        {
            { 409, _ => throw new ShortUrlWithNameAlreadyExistsException() },
        };
    }

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
