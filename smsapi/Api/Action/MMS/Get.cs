using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class MMSGet : BaseSimple<Response.Status>
    {
        protected override string Uri()
        {
            return "mms.do";
        }

        private string[] _ids;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"status", string.Join("|", _ids)}
            };

            return collection;
        }

        public MMSGet Id(string id)
        {
            _ids = new[] {id};
            return this;
        }

        public MMSGet Ids(string[] ids)
        {
            _ids = ids;
            return this;
        }
    }
}