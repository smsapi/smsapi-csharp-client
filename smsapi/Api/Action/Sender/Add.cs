using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SenderAdd : Base<ErrorAwareResponse>
    {
        private string name;

        protected override RequestMethod Method => RequestMethod.POST;

        public SenderAdd SetName(string name)
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
                { "add", name }
            };
        }
    }
}
