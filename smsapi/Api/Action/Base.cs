using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Specialized;
using System.Collections.Generic;
using System;

namespace SMSApi.Api.Action
{
    public abstract class Base<T,TResult>
    {
        protected IClient client;
        protected Proxy proxy;

        abstract protected string Uri();

		protected virtual RequestMethod Method { get { return RequestMethod.POST; } }

        public void Client(IClient client)
        {
            this.client = client;
        }

        public void Proxy(Proxy proxy)
        {
            this.proxy = proxy;
        }

        protected TT ResponseToObject<TT>(Stream data)
        {
			TT result;
			if (data.Length > 0)
			{
				data.Position = 0;
				var serializer = new DataContractJsonSerializer(typeof(TT));
				result = (TT)serializer.ReadObject(data);
				data.Position = 0;
			}
			else
			{
				result = Activator.CreateInstance<TT>();
			}
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

            Stream data = proxy.Execute(Uri(), Values(), Files(), Method);

            TResult result = default(TResult);

            HandleError(data);

            try
            {
                T response = ResponseToObject<T>(data);
                result = ConvertResponse(response);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                //Problem z prasowaniem json'a
                throw new HostException(e.Message + " /" + Uri(), HostException.E_JSON_DECODE);
            }

            data.Close();

            return result;
        }

        protected void HandleError(Stream data) {

            data.Position = 0;

            try
            {
                var error = ResponseToObject<Response.Error>(data);

                if (error.isError())
                {
                    if (isHostError(error.Code))
                    {
                        throw new HostException(error.Message, error.Code);
                    }
                    if (isClientError(error.Code))
                    {
                        throw new ClientException(error.Message, error.Code);
                    }
                    else
                    {
                        throw new ActionException(error.Message, error.Code);
                    }
                }
            }
            catch (System.Runtime.Serialization.SerializationException e) 
            { 
            }

            data.Position = 0;
        }

        /**
         * 101 Niepoprawne lub brak danych autoryzacji.
         * 102 Nieprawidłowy login lub hasło
         * 103 Brak punków dla tego użytkownika
         * 105 Błędny adres IP
         * 110 Usługa nie jest dostępna na danym koncie
         * 1000 Akcja dostępna tylko dla użytkownika głównego
         * 1001 Nieprawidłowa akcja
         */
        private bool isClientError(string code)
        {
            if (code == "101") return true;
            if (code == "102") return true;
            if (code == "103") return true;
            if (code == "105") return true;
            if (code == "110") return true;
            if (code == "1000") return true;
            if (code == "1001") return true;

            return false;
        }

        /**
         * 8 Błąd w odwołaniu
         * 666 Wewnętrzny błąd systemu
         * 999 Wewnętrzny błąd systemu
         * 201 Wewnętrzny błąd systemu
         */
        private bool isHostError(string code)
        {
            if (code == "8") return true;
            if (code == "201") return true;
            if (code == "666") return true;
            if (code == "999") return true;

            return false;
        }
    }
}
