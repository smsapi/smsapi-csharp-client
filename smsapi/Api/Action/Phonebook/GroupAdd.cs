using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupAdd : BaseSimple<SMSApi.Api.Response.Group>
    {
        public PhonebookGroupAdd() : base() { }

        protected override string Uri() { return "phonebook.do"; }

        protected string name;
        protected string info;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("add_group", name);
            if (info != null) collection.Add("info", info);

            return collection;
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
