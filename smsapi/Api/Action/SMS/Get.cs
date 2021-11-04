using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SMSGet : BaseSimple<Status>
    {
        protected string[] id;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("status", string.Join("|", id));

            return collection;
        }
    }
}
