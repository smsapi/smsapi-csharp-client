using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupGet : Base<Group>
    {
        private string name;

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
            return new NameValueCollection
            {
                { "format", "json" },
                { "get_group", name }
            };
        }
    }
}
