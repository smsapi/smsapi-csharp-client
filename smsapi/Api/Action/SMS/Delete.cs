using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SMSDelete : BaseSimple<Countable>
    {
        protected string id;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("sch_del", id);

            return collection;
        }
    }
}
