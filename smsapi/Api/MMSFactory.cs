
namespace SMSApi.Api
{
    public class MMSFactory : Factory
    {
        public MMSFactory()
        { }
        public MMSFactory(Client client) : base(client) { }
        public MMSFactory(Client client, IProxy proxy) : base(client, proxy) { }

        public Action.MMSDelete ActionDelete(string id = null)
        {
            Action.MMSDelete action = new Action.MMSDelete();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public Action.MMSGet ActionGet(string id = null)
        {
            Action.MMSGet action = new Action.MMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public Action.MMSGet ActionGet(string[] id)
        {
            Action.MMSGet action = new Action.MMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Ids(id);

            return action;
        }

        public Action.MMSSend ActionSend(string to = null)
        {
            string[] tos = ( to == null ? null : new string[] { to } );
            return ActionSend(tos);
        }

        public Action.MMSSend ActionSend(string[] to)
        {
            Action.MMSSend action = new Action.MMSSend();
            action.Client(client);
            action.Proxy(proxy);
            action.SetTo(to);

            return action;
        }
    }
}
