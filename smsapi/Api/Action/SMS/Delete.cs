using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SMSDelete : Base<Countable>
    {
        private string id;

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
                { "format", "json" },
                { "sch_del", id }
            };
        }
    }
}
