using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response;
using SMSApi.Api.Response.Deserialization;
using smsapi.Api.Response.Deserialization.Exception;

namespace SMSApi.Api.Action
{
    public class SenderList : Action<Array<Sender>>
    {
        protected override RequestMethod Method => RequestMethod.POST;

        protected override Array<Sender> ResponseToObject(HttpResponseEntity data)
        {
            var result = BaseJsonDeserializer.Deserialize<List<Sender>>(data);
            result.ThrowErrors();
            
            return new Array<Sender>(result.Result);
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
