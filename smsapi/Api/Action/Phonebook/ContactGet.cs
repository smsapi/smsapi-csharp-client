using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class PhonebookContactGet : Base
    {
        public PhonebookContactGet() : base() { }

        protected string number;

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("get_contact", number);

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.Contact Execute()
        {
            Validate();

            Stream data = proxy.Execute("phonebook.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.Contact));
            SMSApi.Api.Response.Contact response = (SMSApi.Api.Response.Contact)serializer.ReadObject(data);
            data.Close();

            this.ValidateResponse(response);

            return response;
        }

        public PhonebookContactGet Number(string number)
        {
            this.number = number;
            return this;
        }
    }
}
