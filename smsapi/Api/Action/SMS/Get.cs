using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SMSGet : BaseSimple<Response.Status>
    {
        public SMSGet() : base() { }

        protected override string Uri() { return "sms.do"; }

        protected string[] id;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("status", string.Join("|", id));

            return collection;
        }

        public SMSGet Id(string id)
        {
            this.id = new string[] { id };
            return this;
        }

        public SMSGet Ids(string[] ids)
        {
            this.id = ids;
            return this;
        }
    }
}
