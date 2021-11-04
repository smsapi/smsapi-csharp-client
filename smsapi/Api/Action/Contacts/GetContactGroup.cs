using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetContactGroup : Rest<Group>
    {
        public GetContactGroup(string contactId, string groupId)
        {
            ContactId = contactId;
            GroupId = groupId;
        }

        public string ContactId { get; private set; }

        public string GroupId { get; private set; }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Resource => "contacts/" + ContactId + "/groups/" + GroupId;
    }
}
