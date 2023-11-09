using System;
using System.Linq;
using System.Net;
using smsapi.Api.Response.Deserialization.Exception;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Deserialization;

public class RestJsonResponseDeserializer : IDeserializer
{
    private readonly LegacyJsonResponseDeserializer legacyJsonResponseDeserializer;
    private readonly IResponseCodeAwareResolver[] responseCodesResolvers;

    public RestJsonResponseDeserializer(
        LegacyJsonResponseDeserializer legacyJsonResponseDeserializer,
        params IResponseCodeAwareResolver[] responseCodesResolvers
    )
    {
        this.legacyJsonResponseDeserializer = legacyJsonResponseDeserializer;
        this.responseCodesResolvers = responseCodesResolvers;
    }

    public DeserializationResult<T> Deserialize<T>(HttpResponseEntity responseEntity)
    {
        if (!typeof(IResponseCodeAwareResolver).IsAssignableFrom(typeof(T)))
            throw new Exception("Deserialization from non-rest response");
        
        var responseStatusCode = (int)responseEntity.StatusCode;
        
        if (responseStatusCode == (int)HttpStatusCode.OK)
            return legacyJsonResponseDeserializer.Deserialize<T>(responseEntity);

        var responseObject = (IResponseCodeAwareResolver)Activator.CreateInstance<T>();
        var exceptionsMatchers = responseObject.HandleExceptionActions()
            .Concat(responseCodesResolvers.SelectMany(resolver => resolver.HandleExceptionActions()));

        var matchedExceptions = exceptionsMatchers
            .Where(pair => pair.Key.Equals(responseStatusCode))
            .ToHashSet();

        if (matchedExceptions.Count > 0) matchedExceptions.First().Value.Invoke(responseEntity.Content.Result);

        HandleUnknownError(responseEntity);

        return default;
    }

    private static void HandleUnknownError(HttpResponseEntity responseEntity)
    {
        throw new UnhandledRestException(
            $"Unknown http status code: {(int)responseEntity.StatusCode}",
            responseEntity.StatusCode.ToString()
        );
    }
}
