using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UserGet : BaseSimple<User>
    {
        protected string username;

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
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("get_user", username);

            return collection;
        }
    }
}
