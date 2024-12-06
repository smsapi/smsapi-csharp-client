namespace SMSApi.Api.Response.Deserialization
{
    internal interface IDeserializer
    {
        public DeserializationResult<T> Deserialize<T>(HttpResponseEntity responseEntity);
    }
}
