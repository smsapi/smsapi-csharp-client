using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class CreateField : Rest<Field>
    {
        public string Name;

        public string Type;

        protected override RequestMethod Method => RequestMethod.POST;

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
                if (Name != null)
                {
                    parameters.Add("name", Name);
                }

                if (Type != null)
                {
                    parameters.Add("type", Type);
                }

                return parameters;
            }
        }

        protected override string Resource => "contacts/fields";

        public CreateField SetName(string name)
        {
            Name = name;
            return this;
        }

        public CreateField SetType(string type)
        {
            Type = type;
            return this;
        }
    }
}
