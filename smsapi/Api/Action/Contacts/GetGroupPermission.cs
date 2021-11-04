using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetGroupPermission : Rest<GroupPermission>
    {
        public GetGroupPermission(string groupId, string username)
        {
            GroupId = groupId;
            Username = username;
        }

        public string GroupId { get; private set; }

        public string Username { get; private set; }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Resource => "contacts/groups/" + GroupId + "/permissions/" + Username;
    }
}
