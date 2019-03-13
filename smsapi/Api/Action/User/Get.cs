using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class UserGet : BaseSimple<Response.User>
    {
        protected override string Uri() => "user.do";

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"get_user", _username}
            };

            return collection;
        }

        private string _username;

        public UserGet Username(string username)
        {
            _username = username;
            return this;
        }
    }
}