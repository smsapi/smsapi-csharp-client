using System;
using System.IO;
using Newtonsoft.Json;

namespace SMSApi.Api.Response.Deserialization;

public class BaseJsonDeserializer : IDeserializer
{
    public DeserializationResult<T> Deserialize<T>(HttpResponseEntity responseEntity)
    {
        T result;
        var data = responseEntity.Content.Result;

        if (data.Length > 0)
        {
            data.Position = 0;
            var stringData = new StreamReader(data).ReadToEnd();

            result = JsonConvert.DeserializeObject<T>(
                stringData,
                new JsonSerializerSettings
                {
                    ContractResolver = new PrivateFieldsContractResolver()
                });
        }
        else
        {
            result = Activator.CreateInstance<T>();
        }

        return new DeserializationResult<T>
        {
            Result = result
        };
    }
}
