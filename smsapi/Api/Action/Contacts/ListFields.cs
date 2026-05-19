using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListFields : ContactsBase<Fields>
    {
        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri()
        {
            return "contacts/fields";
        }
    }
}
