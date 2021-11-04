using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteGroupPermission : Rest<GroupPermission>
    {
        public DeleteGroupPermission(string groupId, string username)
        {
            GroupId = groupId;
            Username = username;
        }

        public string GroupId { get; }

        public string Username { get; }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Resource => "contacts/groups/" + GroupId + "/permissions/" + Username;
    }
}
