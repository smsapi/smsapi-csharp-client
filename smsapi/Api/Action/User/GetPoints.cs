using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UserGetCredits : BaseSimple<Credits>
    {
        protected override string Uri()
        {
            return "user.do";
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("credits", "1");
            collection.Add("details", "1");

            return collection;
        }
    }
}
