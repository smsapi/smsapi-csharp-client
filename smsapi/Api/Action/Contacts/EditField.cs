using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditField : Rest<Field>
    {
        public string Name;

        public EditField(string fieldId)
        {
            FieldId = fieldId;
        }

        public string FieldId { get; }

        protected override RequestMethod Method => RequestMethod.PUT;

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
                if (Name != null)
                {
                    parameters.Add("name", Name);
                }

                return parameters;
            }
        }

        protected override string Resource => "contacts/fields/" + FieldId;

        public EditField SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
