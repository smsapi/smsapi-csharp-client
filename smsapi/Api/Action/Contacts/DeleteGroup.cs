using System;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteGroup : Base<ErrorAwareResponse>
    {
        private readonly string groupId;

        public DeleteGroup(string groupId)
        {
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;

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
