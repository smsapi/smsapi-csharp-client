using System;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetGroup : Base<Group>
    {
        private string groupId;

        public GetGroup(string groupId)
        {
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri()
        {
            return "contacts/groups/" + groupId;
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("GroupId cannot be empty");
            }
        }
    }
}
