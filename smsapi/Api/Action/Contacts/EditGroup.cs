using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditGroup : Base<Group>
    {
        private string description;
        private string groupId;
        private string idx;
        private string name;

        public EditGroup(string groupId)
        {
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.PUT;

        public EditGroup SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public EditGroup SetIdx(string idx)
        {
            this.idx = idx;
            return this;
        }

        public EditGroup SetName(string name)
        {
            this.name = name;
            return this;
        }

        protected override string Uri()
        {
            return "contacts/groups/" + groupId;
        }

        protected override NameValueCollection Values()
        {
            var parameters = new NameValueCollection();
            if (name != null)
            {
                parameters.Add("name", name);
            }

            if (description != null)
            {
                parameters.Add("description", description);
            }

            if (idx != null)
            {
                parameters.Add("idx", idx);
            }

            return parameters;
        }
    }
}
