using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Specialized;
using System.Collections.Generic;
using System;

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
