
namespace SMSApi.Api
{
    public class VMSFactory : Factory
    {
        public VMSFactory() : base() { }
        public VMSFactory(Client client) : base(client) { }

        public VMSFactory(Client client, Proxy proxy) : base(client, proxy)
        {
        }

        public SMSApi.Api.Action.VMSDelete ActionDelete(string id = null)
        {
            SMSApi.Api.Action.VMSDelete action = new SMSApi.Api.Action.VMSDelete();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public SMSApi.Api.Action.VMSGet ActionGet(string id = null)
        {
            SMSApi.Api.Action.VMSGet action = new SMSApi.Api.Action.VMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public SMSApi.Api.Action.VMSGet ActionGet(string[] id)
        {
            SMSApi.Api.Action.VMSGet action = new SMSApi.Api.Action.VMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Ids(id);

            return action;
        }

        public SMSApi.Api.Action.VMSSend ActionSend(string to = null)
        {
            string[] tos = ( to == null ? null : new string[] { to } );
            return ActionSend(tos);
        }

        public SMSApi.Api.Action.VMSSend ActionSend(string[] to)
        {
            SMSApi.Api.Action.VMSSend action = new SMSApi.Api.Action.VMSSend();
            action.Client(client);
            action.Proxy(proxy);
            action.SetTo(to);

            return action;
        }
    }
}
