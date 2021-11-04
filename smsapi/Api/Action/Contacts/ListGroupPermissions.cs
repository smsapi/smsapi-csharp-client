using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListGroupPermissions : Rest<GroupPermissions>
    {
        public ListGroupPermissions(string groupId)
        {
            GroupId = groupId;
        }

        public string GroupId { get; private set; }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Resource => "contacts/groups/" + GroupId + "/permissions";
    }
}
