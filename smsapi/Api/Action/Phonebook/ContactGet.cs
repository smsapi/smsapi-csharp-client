using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookContactGet : BaseSimple<Contact>
    {
        protected string number;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("get_contact", number);

            return collection;
        }
    }
}
