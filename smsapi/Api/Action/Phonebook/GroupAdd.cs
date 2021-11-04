using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupAdd : BaseSimple<Group>
    {
        protected string info;

        protected string name;

        public PhonebookGroupAdd SetInfo(string info)
        {
            this.info = info;
            return this;
        }

        public PhonebookGroupAdd SetName(string name)
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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("add_group", name);
            if (info != null)
            {
                collection.Add("info", info);
            }

            return collection;
        }
    }
}
