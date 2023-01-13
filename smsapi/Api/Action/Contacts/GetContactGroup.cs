using System;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetContactGroup : Base<Group>
    {
        private readonly string contactId;
        private readonly string groupId;

        public GetContactGroup(string contactId, string groupId)
        {
            this.contactId = contactId;
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.GET;

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
