using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class VMSGet : BaseSimple<Status>
    {
        protected string[] ids;

        public VMSGet Id(string id)
        {
            ids = new[] { id };
            return this;
        }

        public VMSGet Ids(string[] ids)
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
            collection.Add("status", string.Join("|", ids));

            return collection;
        }
    }
}
