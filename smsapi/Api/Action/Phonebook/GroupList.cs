using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupList : BaseSimple<SMSApi.Api.Response.Groups>
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
