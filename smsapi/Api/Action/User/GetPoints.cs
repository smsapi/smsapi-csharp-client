using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class UserGetCredits : BaseSimple<SMSApi.Api.Response.Credits>
    {
        public UserGetCredits() : base() { }

        protected override string Uri() { return "user.do"; }

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("credits", "1");

            return collection;
        }
    }
}
