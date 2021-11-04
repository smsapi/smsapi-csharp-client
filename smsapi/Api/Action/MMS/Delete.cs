using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class MMSDelete : BaseSimple<Countable>
    {
        protected string[] ids;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("sch_del", string.Join("|", ids));

            return collection;
        }
    }
}
