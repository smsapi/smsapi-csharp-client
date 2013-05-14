
using System.IO;
using System.Runtime.Serialization.Json;
namespace SMSApi.Api.Action
{
    public abstract class BaseDeprecated
    {
        protected Client client;
        protected Proxy proxy;

        public void Client(Client client)
        {
            this.client = client;
        }

        public void Proxy(Proxy proxy)
        {
            this.proxy = proxy;
        }

        protected T ResponseToObject<T>(Stream data)
        {
            data.Position = 0;

            var serializer = new DataContractJsonSerializer(typeof(T));
            T result = (T)serializer.ReadObject(data);

            data.Position = 0;

            return result;
        }

        protected void ValidateResponse(SMSApi.Api.Response.Base obj)
        {
            if (obj.isError())
            {
                if (isApiError(obj.ErrorCode))
                {
                    throw new ApiException(obj.ErrorMessage, obj.ErrorCode);
                }
            }
        }

        protected void HandleError(Stream data) {

            data.Position = 0;

            try
            {
                var error = ResponseToObject<SMSApi.Api.Response.Error>(data);

                if (error.Code != 0)
                {
                    if (isApiError(error.Code))
                    {
                        throw new ApiException(error.Message, error.Code);
                    }
                    else
                    {
                        throw new ActionException(error.Message, error.Code);
                    }
                }
            }
            catch (System.Runtime.Serialization.SerializationException) { }

            data.Position = 0;
        }

        private bool isApiError(int code)
        {
            if (code == 101) return true;
            if (code == 102) return true;
            if (code == 103) return true;
            if (code == 105) return true;
            if (code == 110) return true;
            if (code == 1000) return true;
            if (code == 1001) return true;

            return false;
        }
    }
}
