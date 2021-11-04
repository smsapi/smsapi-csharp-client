using System.Collections.Generic;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public abstract class BaseArray<T> : Base<List<T>, Array<T>>
    {
        protected override Array<T> ConvertResponse(List<T> response)
        {
            return new Array<T>(response);
        }
    }
}
