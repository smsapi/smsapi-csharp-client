using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SenderSetDefault : BaseSimple<Base>
    {
        private string name;

        public SenderSetDefault Name(string name)
        {
            this.name = name;
            return this;
        }

        protected override string Uri()
        {
            return "sender.do";
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("default", name);

            return collection;
        }
    }
}
