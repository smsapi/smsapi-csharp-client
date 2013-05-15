using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class UserGet : BaseSimple<SMSApi.Api.Response.User>
    {
        public UserGet() : base() { }

        protected override string Uri() { return "user.do"; }

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("get_user", username);

            return collection;
        }

        protected string username;

        public UserGet Username(string username)
        {
            this.username = username;
            return this;
        }
    }
}
