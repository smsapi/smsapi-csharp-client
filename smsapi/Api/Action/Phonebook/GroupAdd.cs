using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupAdd : Base
    {
        public PhonebookGroupAdd() : base() { }

        protected string name;
        protected string info;

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("add_group", name);
            collection.Add("info", info);

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.Base Execute()
        {
            Validate();

            Stream data = proxy.Execute("phonebook.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.Base));
            SMSApi.Api.Response.Base response = (SMSApi.Api.Response.Base)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }

        public PhonebookGroupAdd SetName(string name)
        {
            this.name = name;
            return this;
        }

        public PhonebookGroupAdd SetInfo(string info)
        {
            this.info = info;
            return this;
        }
    }
}
