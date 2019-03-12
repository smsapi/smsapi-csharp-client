using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class MMSDelete : BaseSimple<Response.Countable>
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
                {"sch_del", string.Join("|", _ids)}
            };




            return collection;
        }

        public MMSDelete Id(string id)
        {
            _ids = new[] {id};
            return this;
        }

        public MMSDelete Ids(string[] ids)
        {
            _ids = ids;
            return this;
        }
    }
}