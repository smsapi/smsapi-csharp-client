using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class CreateGroup : Base<Group>
    {
        private string description;
        private string idx;
        private string name;

        public CreateGroup SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public CreateGroup SetIdx(string idx)
        {
            this.idx = idx;
            return this;
        }

        public CreateGroup SetName(string name)
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
            var values = new NameValueCollection();
            if (name != null)
            {
                values.Add("name", name);
            }

            if (description != null)
            {
                values.Add("desciption", description);
            }

            if (idx != null)
            {
                values.Add("idx", idx);
            }

            return values;
        }
    }
}
