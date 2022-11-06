using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public class VMSFactory : Factory
    {
        public VMSFactory(ProxyAddress address = ProxyAddress.SmsApiPl)
            : base(address)
        { }

        public VMSFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl)
            : base(client, address)
        { }

        public VMSFactory(IClient client, Proxy proxy)
            : base(client, proxy)
        { }

        public VMSDelete ActionDelete(string id = null)
        {
            var action = new VMSDelete();
            action.Proxy(proxy);
            action.Id(id);
            return action;
        }

        public VMSGet ActionGet(string id = null)
        {
            var action = new VMSGet();
            action.Proxy(proxy);
            action.Id(id);
            return action;
        }

        public VMSGet ActionGet(string[] id)
        {
            var action = new VMSGet();
            action.Proxy(proxy);
            action.Ids(id);
            return action;
        }

        public VMSSend ActionSend(string to = null)
        {
            string[] tos = to == null ? null : new[] { to };
            return ActionSend(tos);
        }

        public VMSSend ActionSend(string[] to)
        {
            var action = new VMSSend();
            action.Proxy(proxy);
            action.SetTo(to);
            return action;
        }
    }
}
