using System;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteField : Base<Base>
    {
        private readonly string fieldId;

        public DeleteField(string fieldId)
        {
            this.fieldId = fieldId;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Uri()
        {
            return "contacts/fields/" + fieldId;
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(fieldId))
            {
                throw new ArgumentException("FieldId cannot be empty");
            }
        }
    }
}
