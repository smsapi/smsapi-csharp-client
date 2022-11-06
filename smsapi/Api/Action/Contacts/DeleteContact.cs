using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteContact : Base<Base>
    {
        private readonly string contactId;

        public DeleteContact(string contactId)
        {
            this.contactId = contactId;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Uri()
        {
            return "contacts/" + contactId;
        }
    }
}
