using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public class SenderFactory : Factory
    {
        public SenderFactory(ProxyAddress address = ProxyAddress.SmsApiPl)
            : base(address)
        { }

        public SenderFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl)
            : base(client, address)
        { }

        public SenderFactory(IClient client, Proxy proxy)
            : base(client, proxy)
        { }

        public SenderAdd ActionAdd(string name = null)
        {
            var action = new SenderAdd();
            action.Proxy(proxy);
            action.SetName(name);
            return action;
        }

        public SenderDelete ActionDelete(string name = null)
        {
            var action = new SenderDelete();
            action.Proxy(proxy);
            action.Name(name);
            return action;
        }

        public SenderList ActionList()
        {
            var action = new SenderList();
            action.Proxy(proxy);
            return action;
        }

        public SenderSetDefault ActionSetDefault(string name = null)
        {
            var action = new SenderSetDefault();
            action.Proxy(proxy);
            action.Name(name);
            return action;
        }
    }
}
