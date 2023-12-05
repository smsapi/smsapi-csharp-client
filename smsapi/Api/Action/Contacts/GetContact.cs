using System;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetContact : Action<Contact>
    {
        private readonly string contactId;

        public GetContact(string contactId)
        {
            this.contactId = contactId;
        }

        protected override RequestMethod Method => RequestMethod.GET;
        
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
