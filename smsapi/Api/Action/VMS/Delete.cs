using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class VMSDelete : Base<Countable>
    {
        private string[] ids;

        protected override RequestMethod Method => RequestMethod.POST;

        public VMSDelete Id(string id)
        {
            ids = new[] { id };
            return this;
        }

        public VMSDelete Ids(string[] ids)
        {
            this.ids = ids;
            return this;
        }

        protected override string Uri()
        {
            return "vms.do";
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
