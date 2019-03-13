using System.Collections.Specialized;
using System.Collections.Generic;

namespace SMSApi.Api.Action
{
    public class UserList : BaseArray<Response.User>
    {
        protected override string Uri()
        {
            return "user.do";
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"list", "1"}
            };

            return collection;
        }

        private string _username;

        public UserList Username(string username)
        {
            _username = username;
            return this;
        }
    }
}