using System.Collections.Generic;
using System.Collections.Specialized;
using SMSApi.Api.Response;
using SMSApi.Api.Response.Deserialization;
using smsapi.Api.Response.Deserialization.Exception;

namespace SMSApi.Api.Action
{
    public class UserList : Base<Array<User>>
    {
        protected override RequestMethod Method => RequestMethod.POST;

        protected override Array<User> ResponseToObject(HttpResponseEntity data)
        {
            var result = BaseJsonDeserializer.Deserialize<List<User>>(data);
            result.ThrowErrors();
            
            return new Array<User>(result.Result);
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
