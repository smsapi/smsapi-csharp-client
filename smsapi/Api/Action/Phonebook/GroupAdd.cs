using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    [Obsolete("Use CreateGroup")]
    public class PhonebookGroupAdd : Base<Group>
    {
        private string info;
        private string name;

        protected override RequestMethod Method => RequestMethod.POST;

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
            var collection = new NameValueCollection
            {
                { "add_group", name }
            };

            if (info != null)
            {
                collection.Add("info", info);
            }

            return collection;
        }
    }
}
