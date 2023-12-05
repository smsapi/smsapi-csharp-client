using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListContactGroups : Action<Groups>
    {
        private readonly string contactId;

        public ListContactGroups(string contactId)
        {
            this.contactId = contactId;
        }

        protected override RequestMethod Method => RequestMethod.GET;
        
        protected override ApiType ApiType() => Action.ApiType.Rest;

        protected override string Uri()
        {
            return "contacts/" + contactId + "/groups";
        }
    }
}
