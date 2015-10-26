
namespace SMSApi.Api
{
    public class MMSFactory : Factory
    {
        public MMSFactory() : base() { }
        public MMSFactory(Client client) : base(client) { }
        public MMSFactory(Client client, Proxy proxy) : base(client, proxy) { }

        public SMSApi.Api.Action.MMSDelete ActionDelete(string id = null)
        {
            SMSApi.Api.Action.MMSDelete action = new SMSApi.Api.Action.MMSDelete();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public SMSApi.Api.Action.MMSGet ActionGet(string id = null)
        {
            SMSApi.Api.Action.MMSGet action = new SMSApi.Api.Action.MMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public SMSApi.Api.Action.MMSGet ActionGet(string[] id)
        {
            SMSApi.Api.Action.MMSGet action = new SMSApi.Api.Action.MMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Ids(id);

            return action;
        }

        public SMSApi.Api.Action.MMSSend ActionSend(string to = null)
        {
            string[] tos = ( to == null ? null : new string[] { to } );
            return ActionSend(tos);
        }

        public SMSApi.Api.Action.MMSSend ActionSend(string[] to)
        {
            SMSApi.Api.Action.MMSSend action = new SMSApi.Api.Action.MMSSend();
            action.Client(client);
            action.Proxy(proxy);
            action.SetTo(to);

            return action;
        }
    }
}
