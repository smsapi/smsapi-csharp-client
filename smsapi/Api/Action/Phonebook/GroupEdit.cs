using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupEdit : Base
    {
        public PhonebookGroupEdit() : base() { }

        protected string oldName;
        protected string newName;
        protected string info;

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("edit_group", oldName);
            collection.Add("name", newName);
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

        public PhonebookGroupEdit Name(string name)
        {
            this.oldName = name;
            return this;
        }

        public PhonebookGroupEdit SetName(string name)
        {
            this.newName = name;
            return this;
        }

        public PhonebookGroupEdit SetInfo(string info)
        {
            this.info = info;
            return this;
        }
    }
}
