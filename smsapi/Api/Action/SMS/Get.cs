using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SMSGet : BaseSimple<Response.Status>
    {
        protected override string Uri()
        {
            return "sms.do";
        }

        private string[] _id;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"status", string.Join("|", _id)}
            };




            return collection;
        }

        public SMSGet Id(string id)
        {
            this._id = new[] {id};
            return this;
        }

        public SMSGet Ids(string[] ids)
        {
            _id = ids;
            return this;
        }
    }
}