using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetContact : Base<Contact>
    {
        private readonly string contactId;

        public GetContact(string contactId)
        {
            this.contactId = contactId;
        }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri()
        {
            return "contacts/" + contactId;
        }
    }
}
