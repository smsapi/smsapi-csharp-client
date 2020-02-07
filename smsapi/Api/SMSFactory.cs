
namespace SMSApi.Api
{
    public class SMSFactory : Factory
    {
        public SMSFactory(ProxyAddress address = ProxyAddress.SmsApiPl) 
            : base(address) 
        { 
        }

        public SMSFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl) 
            : base(client, address) 
        { 
        }

        public SMSFactory(IClient client, Proxy proxy) 
            : base(client, proxy) 
        { 
        }

        public SMSApi.Api.Action.SMSDelete ActionDelete(string id = null)
        {
            SMSApi.Api.Action.SMSDelete action = new SMSApi.Api.Action.SMSDelete();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public SMSApi.Api.Action.SMSGet ActionGet(string id = null)
        {
            SMSApi.Api.Action.SMSGet action = new SMSApi.Api.Action.SMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public SMSApi.Api.Action.SMSGet ActionGet(string[] id)
        {
            SMSApi.Api.Action.SMSGet action = new SMSApi.Api.Action.SMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Ids(id);

            return action;
        }

        public SMSApi.Api.Action.SMSSend ActionSend(string to = null, string text = null)
        {
            string[] tos = ( to == null ? null : new string[] { to } );
            return ActionSend(tos, text);
        }

        public SMSApi.Api.Action.SMSSend ActionSend(string[] to, string text = null)
        {
            SMSApi.Api.Action.SMSSend action = new SMSApi.Api.Action.SMSSend();
            action.Client(client);
            action.Proxy(proxy);
            action.SetTo(to);
            action.SetText(text);

            return action;
        }
    }
}
