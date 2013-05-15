using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Specialized;
using System.Collections.Generic;
using System;

namespace SMSApi.Api.Action
{
    public abstract class Base<T,TResult>
    {
        protected Client client;
        protected Proxy proxy;

        abstract protected string Uri();

        public void Client(Client client)
        {
            this.client = client;
        }

        public void Proxy(Proxy proxy)
        {
            this.proxy = proxy;
        }

        protected TT ResponseToObject<TT>(Stream data)
        {
            data.Position = 0;

            var serializer = new DataContractJsonSerializer(typeof(TT));
            TT result = (TT)serializer.ReadObject(data);

            data.Position = 0;

            return result;
        }

        abstract protected NameValueCollection Values();
        protected virtual void Validate() { }

        protected virtual Dictionary<string, Stream> Files()
        {
            return null;
        }

        protected abstract TResult ConvertResponse(T response);

/*        protected virtual TResult ConvertResponse(T response)
        {
            return (TResult)Convert.ChangeType(response, typeof(TResult));
        }*/

        public TResult Execute()
        {
            Validate();

            Stream data = proxy.Execute(Uri(), Values(), Files());

            TResult result = default(TResult);

            HandleError(data);

            try
            {
                T response = ResponseToObject<T>(data);
                result = ConvertResponse(response);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                throw new ApiException(e.Message, 999);
            }

            data.Close();

            return result;
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
