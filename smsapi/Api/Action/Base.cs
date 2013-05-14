using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public abstract class Base<T>
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

        public T Execute()
        {
            Validate();

            Stream data = proxy.Execute(Uri(), Values());

            T response = default(T);

            HandleError(data);

            try
            {
                response = ResponseToObject<T>(data);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                throw new ApiException(e.Message, 999);
            }

            data.Close();

            return response;
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
