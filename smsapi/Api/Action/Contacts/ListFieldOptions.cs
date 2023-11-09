using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListFieldOptions : Action<FieldOptions>
    {
        private readonly string fieldId;

        public ListFieldOptions(string fieldId)
        {
            this.fieldId = fieldId;
        }

        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri()
        {
            return "contacts/fields/" + fieldId + "/options";
        }
    }
}
