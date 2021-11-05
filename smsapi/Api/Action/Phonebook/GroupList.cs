using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupList : Base<Groups>
    {
        protected override string Uri()
        {
            return "phonebook.do";
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "format", "json" },
                { "list_groups", "" }
            };
        }
    }
}
