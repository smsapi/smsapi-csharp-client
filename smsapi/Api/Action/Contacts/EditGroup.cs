using System.Collections.Specialized;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class EditGroup : Rest<Group>
    {
        public string Description;

        public string Idx;

        public string Name;

        public EditGroup(string groupId)
        {
            GroupId = groupId;
        }

        public string GroupId { get; }

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

        protected override string Resource => "contacts/groups/" + GroupId;

        public EditGroup SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public EditGroup SetIdx(string idx)
        {
            Idx = idx;
            return this;
        }

        public EditGroup SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
