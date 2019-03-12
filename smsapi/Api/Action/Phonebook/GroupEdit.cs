using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupEdit : BaseSimple<Response.Group>
    {
        protected override string Uri() { return "phonebook.do"; }

        private string _oldName;
        private string _newName;
        private string _info;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"edit_group", _oldName},
                {"name", _newName},
                {"info", _info}
            };




            return collection;
        }

        public PhonebookGroupEdit Name(string name)
        {
            _oldName = name;
            return this;
        }

        public PhonebookGroupEdit SetName(string name)
        {
            _newName = name;
            return this;
        }

        public PhonebookGroupEdit SetInfo(string info)
        {
            _info = info;
            return this;
        }
    }
}
