using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class PhonebookGroupGet : BaseSimple<Response.Group>
    {
        protected override string Uri() => "phonebook.do";

        private string _name;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"get_group", _name}
            };

            return collection;
        }

        public PhonebookGroupGet Name(string name)
        {
            _name = name;
            return this;
        }
    }
}