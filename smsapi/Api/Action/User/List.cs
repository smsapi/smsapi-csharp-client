using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UserList : Base<Array<User>>
    {
        protected override RequestMethod Method => RequestMethod.POST;

        protected override Array<User> ResponseToObject(HttpResponseEntity data)
        {
            return new Array<User>(BaseJsonDeserializer.Deserialize<List<User>>(data));
        }

        protected override string Uri()
        {
            return "user.do";
        }

        protected override NameValueCollection Values()
        {
            return new NameValueCollection
            {
                { "list", "1" }
            };
        }
    }
}
