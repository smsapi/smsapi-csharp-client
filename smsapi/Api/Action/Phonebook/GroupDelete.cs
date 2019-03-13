using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupDelete : BaseSimple<Response.Base>
    {
        public PhonebookGroupDelete()
        {
            _removeContacts = false;
        }

        protected override string Uri()
        {
            return "phonebook.do";
        }

        private string _name;
        private bool _removeContacts;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"delete_group", _name}
            };

            if (_removeContacts == true)
            {
                collection.Add("remove_contacts", "1");
            }

            return collection;
        }

        public PhonebookGroupDelete Name(string name)
        {
            _name = name;
            return this;
        }

        public PhonebookGroupDelete Contacts(bool flag)
        {
            _removeContacts = flag;
            return this;
        }
    }
}