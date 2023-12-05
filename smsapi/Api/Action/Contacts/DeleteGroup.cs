using System;
using SMSApi.Api.Response;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Action
{
    public class DeleteGroup : Action<ErrorAwareResponse>
    {
        private readonly string groupId;

        public DeleteGroup(string groupId)
        {
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;
        
        protected override ApiType ApiType() => Action.ApiType.Rest;

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
