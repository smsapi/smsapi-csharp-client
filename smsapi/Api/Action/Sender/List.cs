using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SenderList : Base<Array<Sender>>
    {
        protected override RequestMethod Method => RequestMethod.POST;

        protected override Array<Sender> ResponseToObject(HttpResponseEntity data)
        {
            return new Array<Sender>(BaseJsonDeserializer.Deserialize<List<Sender>>(data));
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
