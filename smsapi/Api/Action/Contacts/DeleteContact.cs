using System;
using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Action
{
    public class DeleteContact : Action<ErrorAwareResponse>
    {
        private readonly string contactId;

        public DeleteContact(string contactId)
        {
            this.contactId = contactId;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;
        
        protected override ApiType ApiType() => Action.ApiType.Rest;

        protected override string Uri()
        {
            return "contacts/" + contactId;
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(contactId))
            {
                throw new ArgumentException("ContactId cannot be empty");
            }
        }
    }
}
