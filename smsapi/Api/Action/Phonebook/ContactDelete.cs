using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookContactDelete : BaseSimple<Response.Base>
    {
        protected override string Uri() { return "phonebook.do"; }

        private string _number;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection
            {
                {"format", "json"},
                { "username", client.GetUsername()},
                { "password", client.GetPassword()},
                { "delete_contact", _number}
            };

            return collection;
        }

        public PhonebookContactDelete Number(string number)
        {
            _number = number;
            return this;
        }
    }
}
