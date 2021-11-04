using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class UnbindContactFromGroup : Rest<Base>
    {
        public UnbindContactFromGroup(string contactId, string groupId)
        {
            ContactId = contactId;
            GroupId = groupId;
        }

        public string ContactId { get; private set; }

        public string GroupId { get; private set; }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Resource => "contacts/" + ContactId + "/groups/" + GroupId;
    }
}
