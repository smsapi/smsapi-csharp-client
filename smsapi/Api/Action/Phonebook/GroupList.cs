using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    [Obsolete("Use ListGroups")]
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
                { "list_groups", "" }
            };
        }
    }
}
