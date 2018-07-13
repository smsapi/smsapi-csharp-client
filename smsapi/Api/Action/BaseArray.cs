using System.Collections.Generic;

namespace SMSApi.Api.Action
{
    public abstract class BaseArray<T> : Base<List<T>, Response.Array<T>>
    {
        protected override Response.Array<T> ConvertResponse(List<T> response)
        {
            return new Response.Array<T>(response);
        }
    }
}
