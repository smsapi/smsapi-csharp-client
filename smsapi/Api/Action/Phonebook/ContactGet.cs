using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactGet : BaseSimple<SMSApi.Api.Response.Contact>
    {
        public PhonebookContactGet() : base() { }

        protected override string Uri() { return "phonebook.do"; }

        protected string number;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("get_contact", number);

            return collection;
        }

        public PhonebookContactGet Number(string number)
        {
            this.number = number;
            return this;
        }
    }
}
