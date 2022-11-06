using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListContactGroups : Base<Groups>
    {
        private readonly string contactId;

        public ListContactGroups(string contactId)
        {
            this.contactId = contactId;
        }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri()
        {
            return "contacts/" + contactId + "/groups";
        }
    }
}
