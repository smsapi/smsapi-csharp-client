using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SMSDelete : Action<Countable>
    {
        private string id;

        protected override RequestMethod Method => RequestMethod.POST;

        public SMSDelete Id(string id)
        {
            this.id = id;
            return this;
        }

        protected override string Uri()
        {
            return "sms.do";
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "sch_del", id }
            };
        }
    }
}
