namespace SMSApi.Api.Response.Deserialization
{
    public interface IDeserializer
    {
        public T Deserialize<T>(HttpResponseEntity responseEntity);
    }
}
