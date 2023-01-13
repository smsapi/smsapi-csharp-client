using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupDelete : Base<Base>
    {
        private string name;
        private bool removeContacts;

        public PhonebookGroupDelete()
        {
            removeContacts = false;
        }

        public PhonebookGroupDelete Contacts(bool flag)
        {
            removeContacts = flag;
            return this;
        }

        public PhonebookGroupDelete Name(string name)
        {
            this.name = name;
            return this;
        }

        protected override string Uri()
        {
            return "phonebook.do";
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                { "delete_group", name }
            };

            if (removeContacts)
            {
                collection.Add("remove_contacts", "1");
            }

            return collection;
        }
    }
}
