using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class SMSGet : BaseDeprecated
    {
        public SMSGet() : base() { }

        protected string[] _Id;

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("status", string.Join("|", _Id));

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.Status Execute()
        {
            Validate();

            Stream data = proxy.Execute("sms.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.Status));
            SMSApi.Api.Response.Status response = (SMSApi.Api.Response.Status)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }

        public SMSGet Id(string id)
        {
            this._Id = new string[] { id };
            return this;
        }

        public SMSGet Id(string[] ids)
        {
            this._Id = ids;
            return this;
        }
    }
}
