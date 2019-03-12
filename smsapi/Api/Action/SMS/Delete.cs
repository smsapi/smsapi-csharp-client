using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SMSDelete : BaseSimple<Response.Countable>
    {
        public SMSDelete()
        {
        }

        protected override string Uri()
        {
            return "sms.do";
        }

        protected string id;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"sch_del", id}
            };




            return collection;
        }

        public SMSDelete Id(string id)
        {
            this.id = id;
            return this;
        }
    }
}