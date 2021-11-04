using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class PhonebookContactDelete : BaseSimple<Base>
    {
        protected string number;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("delete_contact", number);

            return collection;
        }
    }
}
