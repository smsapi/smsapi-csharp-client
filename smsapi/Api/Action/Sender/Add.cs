using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderAdd : BaseSimple<Response.Base>
    {
        private string name;

        protected override string Uri()
        {
            return "sender.do";
        }

        public SenderAdd SetName(string name)
        {
            this.name = name;
            return this;
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"add", name}
            };

            return collection;
        }
    }
}