using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupDelete : Base
    {
        public PhonebookGroupDelete() : base() {
            removeContacts = false;
        }

        protected string name;
        protected bool removeContacts;

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("delete_group", name);

            if (removeContacts == true)
            {
                collection.Add("remove_contacts", "1");
            }

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

        public PhonebookGroupDelete Name(string name)
        {
            this.name = name;
            return this;
        }

        public PhonebookGroupDelete Contacts(bool flag)
        {
            this.removeContacts = flag;
            return this;
        }
    }
}
