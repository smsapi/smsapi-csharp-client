using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class GetContact : Rest<Contact>
    {
        public GetContact(string contactId)
        {
            ContactId = contactId;
        }

        public string ContactId { get; private set; }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Resource => "contacts/" + ContactId;
    }
}
