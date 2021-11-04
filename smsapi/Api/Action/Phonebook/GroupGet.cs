using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupGet : BaseSimple<Group>
    {
        protected string name;

        public PhonebookGroupGet Name(string name)
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
            collection.Add("get_group", name);

            return collection;
        }
    }
}
