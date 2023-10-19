using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SenderSetDefault : Base<ErrorAwareResponse>
    {
        private string name;

        protected override RequestMethod Method => RequestMethod.POST;

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
                { "default", name }
            };
        }
    }
}
