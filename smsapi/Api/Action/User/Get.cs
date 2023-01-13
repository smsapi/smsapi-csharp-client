using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UserGet : Base<User>
    {
        private string username;

        public UserGet Username(string username)
        {
            this.username = username;
            return this;
        }

        protected override string Uri()
        {
            return "user.do";
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "get_user", username }
            };
        }
    }
}
