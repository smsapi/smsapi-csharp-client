using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SMSGet : Base<Status>
    {
        private string[] id;

        public SMSGet Id(string id)
        {
            this.id = new[] { id };
            return this;
        }

        public SMSGet Ids(string[] ids)
        {
            id = ids;
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
                { "status", string.Join("|", id) }
            };
        }
    }
}
