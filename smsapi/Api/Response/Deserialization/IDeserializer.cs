namespace SMSApi.Api.Response.Deserialization
{
    public interface IDeserializer
    {
        public DeserializationResult<T> Deserialize<T>(HttpResponseEntity responseEntity);
    }
}
