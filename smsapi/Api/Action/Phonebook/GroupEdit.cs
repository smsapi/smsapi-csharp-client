using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupEdit : Base<Group>
    {
        private string info;
        private string newName;
        private string oldName;

        public PhonebookGroupEdit Name(string name)
        {
            oldName = name;
            return this;
        }

        public PhonebookGroupEdit SetInfo(string info)
        {
            this.info = info;
            return this;
        }

        public PhonebookGroupEdit SetName(string name)
        {
            newName = name;
            return this;
        }

        protected override string Uri()
        {
            return "phonebook.do";
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "format", "json" },
                { "edit_group", oldName },
                { "name", newName },
                { "info", info }
            };
        }
    }
}
