using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditField : Base<Field>
    {
        private string fieldId;
        private string name;

        public EditField(string fieldId)
        {
            this.fieldId = fieldId;
        }

        protected override RequestMethod Method => RequestMethod.PUT;

        public EditField SetName(string name)
        {
            this.name = name;
            return this;
        }

        protected override string Uri()
        {
            return "contacts/fields/" + fieldId;
        }

        protected override NameValueCollection Values()
        {
            var parameters = new NameValueCollection();
            if (name != null)
            {
                parameters.Add("name", name);
            }

            return parameters;
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
