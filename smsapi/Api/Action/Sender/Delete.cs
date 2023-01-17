using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SenderDelete : Base<Base>
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
