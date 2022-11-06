using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UserList : Base<Array<User>>
    {
        protected override Array<User> ResponseToObject(Stream data)
        {
            return new Array<User>(Deserialize<List<User>>(data));
        }

        protected override string Uri()
        {
            return "user.do";
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "format", "json" },
                { "list", "1" }
            };
        }
    }
}
