using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UnbindContactFromGroup : Base<Base>
    {
        private readonly string contactId;
        private readonly string groupId;

        public UnbindContactFromGroup(string contactId, string groupId)
        {
            this.contactId = contactId;
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Uri()
        {
            return "contacts/" + contactId + "/groups/" + groupId;
        }
    }
}
