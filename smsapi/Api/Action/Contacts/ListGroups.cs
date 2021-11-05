using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class ListGroups : Base<Groups>
    {
        private string id;
        private string name;

        protected override RequestMethod Method => RequestMethod.GET;

        public ListGroups SetId(string id)
        {
            this.id = id;
            return this;
        }

        public ListGroups SetName(string name)
        {
            this.name = name;
            return this;
        }

        protected override string Uri()
        {
            return "contacts/groups";
        }

        protected override NameValueCollection Values()
        {
            var parameters = new NameValueCollection
            {
                { "with", "contacts_count" }
            };

            if (id != null)
            {
                parameters.Add("id", id);
            }

            if (name != null)
            {
                parameters.Add("name", name);
            }

            return parameters;
        }
    }
}
