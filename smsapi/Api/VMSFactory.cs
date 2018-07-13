
namespace SMSApi.Api
{
    public class VMSFactory : Factory
    {
        public VMSFactory() : base() { }
        public VMSFactory(Client client) : base(client) { }

        public VMSFactory(Client client, Proxy proxy) : base(client, proxy)
        {
        }

        public Action.VMSDelete ActionDelete(string id = null)
        {
            Action.VMSDelete action = new Action.VMSDelete();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public Action.VMSGet ActionGet(string id = null)
        {
            Action.VMSGet action = new Action.VMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public Action.VMSGet ActionGet(string[] id)
        {
            Action.VMSGet action = new Action.VMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Ids(id);

            return action;
        }

        public Action.VMSSend ActionSend(string to = null)
        {
            string[] tos = ( to == null ? null : new string[] { to } );
            return ActionSend(tos);
        }

        public Action.VMSSend ActionSend(string[] to)
        {
            Action.VMSSend action = new Action.VMSSend();
            action.Client(client);
            action.Proxy(proxy);
            action.SetTo(to);

            return action;
        }
    }
}
