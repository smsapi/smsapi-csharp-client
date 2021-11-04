using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListGroups : Rest<Groups>
    {
        public string Id;

        public string Name;

        protected override RequestMethod Method => RequestMethod.GET;

        protected override NameValueCollection Parameters
        {
            get
            {
                NameValueCollection parameters = base.Parameters;
                parameters.Add("with", "contacts_count");
                if (Id != null)
                {
                    parameters.Add("id", Id);
                }

                if (Name != null)
                {
                    parameters.Add("name", Name);
                }

                return parameters;
            }
        }

        protected override string Resource => "contacts/groups";

        public ListGroups SetId(string id)
        {
            Id = id;
            return this;
        }

        public ListGroups SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
