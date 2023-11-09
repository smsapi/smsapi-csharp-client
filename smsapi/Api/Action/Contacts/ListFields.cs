using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListFields : Action<Fields>
    {
        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri()
        {
            return "contacts/fields";
        }
    }
}
