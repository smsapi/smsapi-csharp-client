using System;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    [Obsolete("Use DeleteContact")]
    public class PhonebookContactDelete : Base<Base>
    {
        private string number;

        protected override RequestMethod Method => RequestMethod.POST;

        public PhonebookContactDelete Number(string number)
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
                { "delete_contact", number }
            };
        }
    }
}
