using System;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Action
{
    public class UnbindContactFromGroup : Action<ErrorAwareResponse>
    {
        private readonly string contactId;
        private readonly string groupId;

        public UnbindContactFromGroup(string contactId, string groupId)
        {
            this.contactId = contactId;
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;
        
        protected override ApiType ApiType() => Action.ApiType.Rest;

        protected override string Uri()
        {
            return "contacts/" + contactId + "/groups/" + groupId;
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(contactId))
            {
                throw new ArgumentException("ContactId cannot be empty");
            }

            if (string.IsNullOrEmpty(groupId))
            {
                throw new ArgumentException("GroupId cannot be empty");
            }
        }
    }
}
