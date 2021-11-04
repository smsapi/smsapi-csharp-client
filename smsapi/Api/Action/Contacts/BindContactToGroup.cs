using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class BindContactToGroup : Rest<Base>
    {
        public BindContactToGroup(string contactId, string groupId)
        {
            ContactId = contactId;
            GroupId = groupId;
        }

        public string ContactId { get; }

        public string GroupId { get; }

        protected override RequestMethod Method => RequestMethod.PUT;

        protected override string Resource => "contacts/" + ContactId + "/groups/" + GroupId;
    }
}
