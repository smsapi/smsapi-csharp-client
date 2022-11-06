using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListGroupPermissions : Base<GroupPermissions>
    {
        private string groupId;

        public ListGroupPermissions(string groupId)
        {
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri()
        {
            return "contacts/groups/" + groupId + "/permissions";
        }
    }
}
