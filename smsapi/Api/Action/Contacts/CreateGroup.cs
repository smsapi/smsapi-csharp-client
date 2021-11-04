using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class CreateGroup : Rest<Group>
    {
        public string Description;

        public string Idx;

        public string Name;

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

                if (Description != null)
                {
                    parameters.Add("desciption", Description);
                }

                if (Idx != null)
                {
                    parameters.Add("idx", Idx);
                }

                return parameters;
            }
        }

        protected override string Resource => "contacts/groups";

        public CreateGroup SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public CreateGroup SetIdx(string idx)
        {
            Idx = idx;
            return this;
        }

        public CreateGroup SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
