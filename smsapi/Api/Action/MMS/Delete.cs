using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class MMSDelete : Action<Countable>
    {
        private string[] ids;

        protected override RequestMethod Method => RequestMethod.POST;

        public MMSDelete Id(string id)
        {
            ids = new[] { id };
            return this;
        }

        public MMSDelete Ids(string[] ids)
        {
            this.ids = ids;
            return this;
        }

        protected override string Uri()
        {
            return "mms.do";
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "sch_del", string.Join("|", ids) }
            };
        }
    }
}
