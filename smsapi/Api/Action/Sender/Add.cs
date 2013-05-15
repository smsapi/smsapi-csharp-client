using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SenderAdd : BaseSimple<SMSApi.Api.Response.Base>
    {
        private string name;

        protected override string Uri() { return "sender.do"; }

        public SenderAdd SetName(string name)
        {
            this.name = name;
            return this;
        }

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("add", name);

            return collection;
        }
    }
}
