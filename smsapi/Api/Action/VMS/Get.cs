using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class VMSGet : BaseSimple<Response.Status>
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
                {"status", string.Join("|", _ids)}
            };

            return collection;
        }

        public VMSGet Id(string id)
        {
            _ids = new[] {id};
            return this;
        }


        public VMSGet Ids(string[] ids)
        {
            _ids = ids;
            return this;
        }
    }
}