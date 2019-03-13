using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class VMSDelete : BaseSimple<Response.Countable>
    {
        protected override string Uri() => "vms.do";

        private string[] _ids;

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"sch_del", string.Join("|", _ids)}
            };

            return collection;
        }

        public VMSDelete Id(string id)
        {
            _ids = new[] {id};
            return this;
        }

        public VMSDelete Ids(string[] ids)
        {
            _ids = ids;
            return this;
        }
    }
}