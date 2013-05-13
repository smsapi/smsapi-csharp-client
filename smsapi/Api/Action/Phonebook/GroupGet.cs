using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupGet : Base
    {
        public PhonebookGroupGet() : base() { }

        protected string name;

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("get_group", name);

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.Group Execute()
        {
            Validate();

            Stream data = proxy.Execute("phonebook.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.Group));
            SMSApi.Api.Response.Group response = (SMSApi.Api.Response.Group)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }

        public PhonebookGroupGet Name(string name)
        {
            this.name = name;
            return this;
        }
    }
}
