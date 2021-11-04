using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupEdit : BaseSimple<Group>
    {
        protected string info;
        protected string newName;

        protected string oldName;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("edit_group", oldName);
            collection.Add("name", newName);
            collection.Add("info", info);

            return collection;
        }
    }
}
