using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetGroup : Rest<Group>
    {
        public GetGroup(string groupId)
        {
            GroupId = groupId;
        }

        public string GroupId { get; private set; }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Resource => "contacts/groups/" + GroupId;
    }
}
