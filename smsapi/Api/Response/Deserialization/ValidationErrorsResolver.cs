using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using smsapi.Api.Response.Deserialization.Exception;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Deserialization;

public class ValidationErrorsResolver : IResponseCodeAwareResolver
{
    private readonly BaseJsonDeserializer baseJsonDeserializer;

    public ValidationErrorsResolver(BaseJsonDeserializer baseJsonDeserializer)
    {
        this.baseJsonDeserializer = baseJsonDeserializer;
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
        var validationErrors = baseJsonDeserializer.Deserialize<ValidationErrors>(
            new HttpResponseEntity(Task.FromResult(stream), HttpStatusCode.BadRequest)
        ).Result;

        throw ValidationException.Create(validationErrors);
    }

    [DataContract]
    public readonly struct ValidationErrors
    {
        [DataMember(Name = "errors")] public readonly IEnumerable<ValidationError> Errors;
    }

    [DataContract]
    public readonly struct ValidationError
    {
        [DataMember(Name = "message")] public readonly string Message;

        [DataMember(Name = "error")] public readonly string Error;
    }
}
