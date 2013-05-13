using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupList : Base
    {
        public PhonebookGroupList()
            : base()
        {
        }

        private NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("list_groups", "");

            return collection;
        }

        private void Validate()
        {
        }

        public SMSApi.Api.Response.Groups Execute()
        {
            Validate();

            Stream data = proxy.Execute("phonebook.do", Values());

            var serializer = new DataContractJsonSerializer(typeof(SMSApi.Api.Response.Groups));
            SMSApi.Api.Response.Groups response = (SMSApi.Api.Response.Groups)serializer.ReadObject(data);
            data.Close();

            return response;
        }
    }
}
