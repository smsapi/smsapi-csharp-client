using SMSApi.Api.Response;

namespace SMSApi.Api.Action
{
    public class DeleteGroup : Base<Base>
    {
        private readonly string groupId;

        public DeleteGroup(string groupId)
        {
            this.groupId = groupId;
        }

        protected override RequestMethod Method => RequestMethod.DELETE;

        protected override string Uri()
        {
            return "contacts/groups/" + groupId;
        }
    }
}
