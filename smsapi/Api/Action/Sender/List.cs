using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class SenderList : BaseArray<Sender>
    {
        protected override string Uri()
        {
            return "sender.do";
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("list", "1");

            return collection;
        }
    }
}
