using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SenderList : Base<Array<Sender>>
    {
        protected override Array<Sender> ResponseToObject(Stream data)
        {
            return new Array<Sender>(Deserialize<List<Sender>>(data));
        }

        protected override string Uri()
        {
            return "sender.do";
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "list", "1" }
            };
        }
    }
}
