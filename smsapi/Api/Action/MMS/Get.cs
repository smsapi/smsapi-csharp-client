using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class MMSGet : Base<Status>
    {
        private string[] ids;

        public MMSGet Id(string id)
        {
            ids = new[] { id };
            return this;
        }

        public MMSGet Ids(string[] ids)
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
                { "status", string.Join("|", ids) }
            };
        }
    }
}
