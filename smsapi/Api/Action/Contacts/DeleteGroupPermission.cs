using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteGroupPermission : Base<GroupPermission>
    {
        private readonly string groupId;
        private readonly string username;

        public DeleteGroupPermission(string groupId, string username)
        {
            this.groupId = groupId;
            this.username = username;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Uri()
        {
            return "contacts/groups/" + groupId + "/permissions/" + username;
        }
    }
}
