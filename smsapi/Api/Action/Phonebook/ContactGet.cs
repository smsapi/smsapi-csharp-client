using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    [Obsolete("Use GetContact")]
    public class PhonebookContactGet : Base<Contact>
    {
        private string number;

        protected override RequestMethod Method => RequestMethod.POST;

        public PhonebookContactGet Number(string number)
        {
            this.number = number;
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
                { "get_contact", number }
            };
        }
    }
}
