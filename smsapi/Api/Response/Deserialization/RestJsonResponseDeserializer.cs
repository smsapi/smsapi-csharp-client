using System;
using System.Linq;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Deserialization;

public class RestJsonResponseDeserializer : IDeserializer
{
    private readonly ValidationErrorsResolver validationErrorsResolver;
    private readonly LegacyJsonResponseDeserializer legacyJsonResponseDeserializer;

    public RestJsonResponseDeserializer(
        LegacyJsonResponseDeserializer legacyJsonResponseDeserializer,
        ValidationErrorsResolver validationErrorsResolver
    )
    {
        this.legacyJsonResponseDeserializer = legacyJsonResponseDeserializer;
        this.validationErrorsResolver = validationErrorsResolver;
    }

    public DeserializationResult<T> Deserialize<T>(HttpResponseEntity responseEntity)
    {
        if (!typeof(IResponseCodeAwareResolver).IsAssignableFrom(typeof(T)))
            throw new Exception("Deserialization from non-rest response");

        var responseObject = (IResponseCodeAwareResolver)Activator.CreateInstance<T>();
        var responseStatusCode = (int)responseEntity.StatusCode;
        
        var exceptionsMatchers =
            responseObject.HandleExceptionActions()
                .Concat(validationErrorsResolver.HandleExceptionActions());

        var matchedExceptions = exceptionsMatchers
            .Where(pair => pair.Key.Equals(responseStatusCode))
            .ToHashSet();

        if (matchedExceptions.Count > 0) matchedExceptions.First().Value.Invoke(responseEntity.Content.Result);

        return legacyJsonResponseDeserializer.Deserialize<T>(responseEntity);
    }
}
