using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactGet : BaseSimple<Response.Contact>
    {
        protected override string Uri()
        {
            return "phonebook.do";
        }

        private string _number;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"get_contact", _number}
            };

            return collection;
        }

        public PhonebookContactGet Number(string number)
        {
            _number = number;
            return this;
        }
    }
}