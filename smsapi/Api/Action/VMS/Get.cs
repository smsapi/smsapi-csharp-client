using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class VMSGet : Base<Status>
    {
        private string[] ids;

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
            return new NameValueCollection
            {
                { "format", "json" },
                { "status", string.Join("|", ids) }
            };
        }
    }
}
