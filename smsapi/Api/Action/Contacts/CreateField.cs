using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class CreateField : Action<Field>
    {
        private string name;
        private string type;

        protected override RequestMethod Method => RequestMethod.POST;

        public CreateField SetName(string name)
        {
            this.name = name;
            return this;
        }

        public CreateField SetType(string type)
        {
            this.type = type;
            return this;
        }

        protected override string Uri()
        {
            return "contacts/fields";
        }

        protected override NameValueCollection Values()
        {
            var values = new NameValueCollection();
            if (name != null)
            {
                values.Add("name", name);
            }

            if (type != null)
            {
                values.Add("type", type);
            }

            return values;
        }
    }
}
