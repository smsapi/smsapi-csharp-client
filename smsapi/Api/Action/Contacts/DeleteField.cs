using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteField : Rest<Base>
    {
        public DeleteField(string fieldId)
        {
            FieldId = fieldId;
        }

        public string FieldId { get; }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Resource => "contacts/fields/" + FieldId;
    }
}
