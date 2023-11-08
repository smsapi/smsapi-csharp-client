using System;
using System.Linq;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Deserialization
{
    public class RestJsonResponseDeserializer : IDeserializer
    {
        private readonly LegacyJsonResponseDeserializer legacyJsonResponseDeserializer;

        public RestJsonResponseDeserializer(LegacyJsonResponseDeserializer legacyJsonResponseDeserializer)
        {
            this.legacyJsonResponseDeserializer = legacyJsonResponseDeserializer;
        }

        public DeserializationResult<T> Deserialize<T>(HttpResponseEntity responseEntity)
        {
            if (!typeof(IResponseCodeAwareResolver).IsAssignableFrom(typeof(T)))
                throw new Exception("Deserialization from non-rest response");

            var responseObject = (IResponseCodeAwareResolver)Activator.CreateInstance<T>();
            var responseStatusCode = (int)responseEntity.StatusCode;

            var matchedExceptions = responseObject.CodeToException()
                .Where(pair => pair.Key.Equals(responseStatusCode))
                .ToHashSet();

            if (matchedExceptions.Count > 0)
            {
                matchedExceptions.First().Value.Invoke();
            }

            return legacyJsonResponseDeserializer.Deserialize<T>(responseEntity);
        }
    }
}
