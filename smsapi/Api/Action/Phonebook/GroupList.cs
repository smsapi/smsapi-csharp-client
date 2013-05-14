using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupList : Base<SMSApi.Api.Response.Groups>
    {
        public PhonebookGroupList()
            : base()
        {
        }

        protected override string Uri() { return "phonebook.do"; }

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("list_groups", "");

            return collection;
        }
    }
}
