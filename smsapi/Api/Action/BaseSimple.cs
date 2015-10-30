namespace SMSApi.Api.Action
{
    public abstract class BaseSimple<T> : Base<T, T>
    {
        protected override T ConvertResponse(T response)
        {
            return response;
        }
    }
}
