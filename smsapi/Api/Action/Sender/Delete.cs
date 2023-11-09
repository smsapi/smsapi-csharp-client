using System.Collections.Specialized;
using SMSApi.Api.Response;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Action
{
    public class SenderDelete : Action<ErrorAwareResponse>
    {
        private string name;

        protected override RequestMethod Method => RequestMethod.POST;

        public SenderDelete Name(string name)
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
                { "delete", name }
            };
        }
    }
}
