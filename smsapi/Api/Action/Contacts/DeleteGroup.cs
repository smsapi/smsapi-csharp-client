using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteGroup : Rest<Base>
    {
        public DeleteGroup(string groupId)
        {
            GroupId = groupId;
        }

        public string GroupId { get; }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Resource => "contacts/groups/" + GroupId;
    }
}
