using System;
using System.IO;
using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.Deserialization
{
    public class LegacyJsonResponseDeserializer : IDeserializer
    {
        private readonly BaseJsonDeserializer _baseJsonDeserializer = new();

        public T Deserialize<T>(HttpResponseEntity responseEntity)
        {
            T response;
            Stream data = null;

            try
            {
                HandleError(responseEntity);
                data = responseEntity.Content.Result;
                response = _baseJsonDeserializer.Deserialize<T>(responseEntity);
            }
            catch (SerializationException e)
            {
                throw new HostException(e.Message, HostException.E_JSON_DECODE);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                data?.Close();
            }

            return response;
        }

        private void HandleError(HttpResponseEntity responseEntity)
        {
            try
            {
                var error = _baseJsonDeserializer.Deserialize<ErrorAwareResponse>(responseEntity);

                if (!error.IsError()) return;
                
                if (IsHostError(error.ErrorCode))
                    throw new HostException(error.GetErrorMessage(), Convert.ToString(error.ErrorCode));

                if (IsClientError(error.ErrorCode))
                    throw new ClientException(error.GetErrorMessage(), error.ErrorCode);

                throw new ActionException(error.GetErrorMessage(), error.ErrorCode);
            }
            catch (SerializationException)
            {
            }
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
        private static bool IsClientError(int code)
        {
            switch (code)
            {
                case 101:
                case 102:
                case 103:
                case 105:
                case 110:
                case 1000:
                case 1001:
                    return true;

                default:
                    return false;
            }
        }

        /**
         * 8 Błąd w odwołaniu
         * 666 Wewnętrzny błąd systemu
         * 999 Wewnętrzny błąd systemu
         * 201 Wewnętrzny błąd systemu
         */
        private static bool IsHostError(int code)
        {
            switch (code)
            {
                case 8:
                case 201:
                case 666:
                case 999:
                    return true;

                default:
                    return false;
            }
        }
    }
}
