
namespace SMSApi.Api
{
    public class VMSFactory : Factory
    {
        public VMSFactory(ProxyAddress address = ProxyAddress.SmsApiPl) 
            : base(address) 
        { 
        }

        public VMSFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl) 
            : base(client, address) 
        { 
        }

        public VMSFactory(IClient client, Proxy proxy) 
            : base(client, proxy)
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
