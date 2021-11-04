using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class VMSDelete : BaseSimple<Countable>
    {
        protected string[] ids;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("sch_del", string.Join("|", ids));

            return collection;
        }
    }
}
