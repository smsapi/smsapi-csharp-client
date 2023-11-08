using System;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Response.Deserialization
{
    public class BaseJsonDeserializer : IDeserializer
    {
        public DeserializationResult<T> Deserialize<T>(HttpResponseEntity responseEntity)
        {
            T result;
            var data = responseEntity.Content.Result;
            
            if (data.Length > 0)
            {
                data.Position = 0;
                var serializer = new DataContractJsonSerializer(typeof(T));
                result = (T)serializer.ReadObject(data);
                data.Position = 0;
            }
            else
            {
                result = Activator.CreateInstance<T>();
            }

            var deserializationResult = new DeserializationResult<T>();
            deserializationResult.Result = result;

            return deserializationResult;
        }
    }
}
