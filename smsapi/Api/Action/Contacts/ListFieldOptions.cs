using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListFieldOptions : Rest<FieldOptions>
    {
        public ListFieldOptions(string fieldId)
        {
            FieldId = fieldId;
        }

        public string FieldId { get; private set; }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Resource => "contacts/fields/" + FieldId + "/options";
    }
}
