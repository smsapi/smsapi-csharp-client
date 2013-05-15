using System.Collections.Generic;

namespace SMSApi.Api.Action
{
    public abstract class BaseArray<T> : Base<List<T>, SMSApi.Api.Response.Array<T>>
    {
        protected override SMSApi.Api.Response.Array<T> ConvertResponse(List<T> response)
        {
            return new SMSApi.Api.Response.Array<T>(response);
        }
    }
}
