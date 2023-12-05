using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListFields : Action<Fields>
    {
        protected override RequestMethod Method => RequestMethod.GET;
        
        protected override ApiType ApiType() => Action.ApiType.Rest;

        protected override string Uri()
        {
            return "contacts/fields";
        }
    }
}
