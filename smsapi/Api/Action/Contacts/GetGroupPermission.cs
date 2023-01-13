using System;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetGroupPermission : Base<GroupPermission>
    {
        private readonly string groupId;
        private readonly string username;

        public GetGroupPermission(string groupId, string username)
        {
            this.groupId = groupId;
            this.username = username;
        }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri()
        {
            return "contacts/groups/" + groupId + "/permissions/" + username;
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be empty");
            }

            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("GroupId cannot be empty");
            }
        }
    }
}
