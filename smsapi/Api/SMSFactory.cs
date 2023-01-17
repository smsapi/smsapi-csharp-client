using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public class SMSFactory : Factory
    {
        public SMSFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
            : base(address)
        { }

        public SMSFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
            : base(client, address)
        { }

        public SMSFactory(IClient client, Proxy proxy)
            : base(client, proxy)
        { }

        public SMSDelete ActionDelete(string id = null)
        {
            var action = new SMSDelete();
            action.Proxy(proxy);
            action.Id(id);
            return action;
        }

        public SMSGet ActionGet(string id = null)
        {
            var action = new SMSGet();
            action.Proxy(proxy);
            action.Id(id);
            return action;
        }

        public SMSGet ActionGet(string[] id)
        {
            var action = new SMSGet();
            action.Proxy(proxy);
            action.Ids(id);
            return action;
        }

        public SMSSend ActionSend(string to = null, string text = null)
        {
            string[] tos = to == null ? null : new[] { to };
            return ActionSend(tos, text);
        }

        public SMSSend ActionSend(string[] to, string text = null)
        {
            var action = new SMSSend();
            action.Proxy(proxy);
            action.SetTo(to);
            action.SetText(text);
            return action;
        }
    }
}
