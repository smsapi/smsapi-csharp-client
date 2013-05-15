using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class MMSGet : BaseSimple<SMSApi.Api.Response.Status>
    {
        public MMSGet() : base() { }

        protected override string Uri() { return "mms.do"; }

        protected string[] ids;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("status", string.Join("|", ids));

            return collection;
        }

        public MMSGet Id(string id)
        {
            this.ids = new string[] { id };
            return this;
        }

        public MMSGet Ids(string[] ids)
        {
            this.ids = ids;
            return this;
        }
    }
}
