using System;
using SMSApi.Api;
using SMSApi.Api.Response.Deserialization;

namespace smsapi.Api.Response.Deserialization.Exception
{
    public static class DeserializationExceptionManager
    {
        public static void ThrowErrors<T>(this DeserializationResult<T> dr)
        {
            if (dr.ClientError != null)
                throw new ClientException(dr.ClientError.Value.Message, dr.ClientError.Value.Code);

            if (dr.HostError != null)
                throw new HostException(dr.HostError.Value.Message, Convert.ToString(dr.HostError.Value.Code));

            if (dr.ActionError != null)
                throw new HostException(dr.ActionError.Value.Message, Convert.ToString(dr.ActionError.Value.Code));
        }
    }
}
