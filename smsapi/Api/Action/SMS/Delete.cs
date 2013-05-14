using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SMSDelete : Base<SMSApi.Api.Response.Countable>
    {
        public SMSDelete() : base() { }

        protected override string Uri() { return "sms.do"; }

        protected string[] ids;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("sch_del", string.Join("|", ids));

            return collection;
        }

        public SMSDelete Id(string id)
        {
            this.ids = new string[] { id };
            return this;
        }


        public SMSDelete Id(string[] ids)
        {
            this.ids = ids;
            return this;
        }
    }
}
