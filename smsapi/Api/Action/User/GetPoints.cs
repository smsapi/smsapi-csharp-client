using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class UserGetCredits : BaseSimple<Response.Credits>
    {
        protected override string Uri() => "user.do";

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"credits", "1"},
                {"details", "1"}
            };

            return collection;
        }
    }
}