using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SMSApi.Api.Response.ResponseResolver;
using smsapi.Api.Response.REST.Exception;

namespace SMSApi.Api.Response.Deserialization;

public class ValidationErrorsResolver : IResponseCodeAwareResolver
{
    private readonly BaseJsonDeserializer _baseJsonDeserializer;

    public ValidationErrorsResolver(BaseJsonDeserializer baseJsonDeserializer)
    {
        _baseJsonDeserializer = baseJsonDeserializer;
    }

    public Dictionary<int, Action<Stream>> HandleExceptionActions()
    {
        return new Dictionary<int, Action<Stream>>
        {
            { 400, ResolveErrors }
        };
    }

    private void ResolveErrors(Stream stream)
    {
        var validationErrors = _baseJsonDeserializer.Deserialize<ValidationErrors>(
            new HttpResponseEntity(Task.FromResult(stream), HttpStatusCode.BadRequest)
        ).Result;

        throw ValidationException.Create(validationErrors);
    }
    
    public readonly record struct ValidationErrors
    {
        [JsonProperty("errors")]
        public readonly IEnumerable<ValidationError> Errors;
    }
    
    public readonly record struct ValidationError
    {
        [JsonProperty("message")]
        public readonly string Message;
        
        [JsonProperty("error")]
        public readonly string Error;
    }
}
