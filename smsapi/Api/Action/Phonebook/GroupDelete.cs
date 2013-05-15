using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupDelete : BaseSimple<SMSApi.Api.Response.Base>
    {
        public PhonebookGroupDelete() : base() {
            removeContacts = false;
        }

        protected override string Uri() { return "phonebook.do"; }

        protected string name;
        protected bool removeContacts;

        protected override NameValueCollection Values()
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
