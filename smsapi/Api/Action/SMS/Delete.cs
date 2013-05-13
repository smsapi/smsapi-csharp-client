using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class SMSDelete : Base
    {
        public SMSDelete() : base()
        {
        }

        protected string[] ids;

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("sch_del", string.Join("|", ids));

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.List Execute()
        {
            Validate();

            Stream data = proxy.Execute("sms.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.List));
            SMSApi.Api.Response.List response = (SMSApi.Api.Response.List)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }

        public SMSDelete Id(string id)
        {
            this.ids = new string[] { id };
            return this;
        }


        public SMSDelete Id(string[] ids)
        {
            this.ids = ids;
            return this;
        }
    }
}
