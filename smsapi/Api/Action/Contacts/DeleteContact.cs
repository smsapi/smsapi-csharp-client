using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteContact : Rest<Base>
    {
        public DeleteContact(string contactId)
        {
            ContactId = contactId;
        }

        public string ContactId { get; }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Resource => "contacts/" + ContactId;
    }
}
