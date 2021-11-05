using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SenderSetDefault : Base<Base>
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
            return new NameValueCollection
            {
                { "format", "json" },
                { "default", name }
            };
        }
    }
}
