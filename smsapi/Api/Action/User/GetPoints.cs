using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UserGetCredits : Action<Credits>
    {
        protected override RequestMethod Method => RequestMethod.POST;

        protected override string Uri()
        {
            return "user.do";
        }

        protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
        {
            return (new NameValueCollection
            {
                { "credits", "1" },
                { "details", "1" }
            }, default);
        }
    }
}
