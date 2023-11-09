using SMSApi.Api;
using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public class MMSFactory : Factory
    {
        public MMSFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
            : base(address)
        { }

        public MMSFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
            : base(client, address)
        { }

        public MMSFactory(IClient client, Proxy proxy)
            : base(client, proxy)
        { }

        public MMSDelete ActionDelete(string id = null)
        {
            var action = new MMSDelete();
            action.Proxy(proxy);
            action.Id(id);
            return action;
        }

        public MMSGet ActionGet(string id = null)
        {
            var action = new MMSGet();
            action.Proxy(proxy);
            action.Id(id);
            return action;
        }

        public MMSGet ActionGet(string[] id)
        {
            var action = new MMSGet();
            action.Proxy(proxy);
            action.Ids(id);
            return action;
        }

        public MMSSend ActionSend(string to = null)
        {
            string[] tos = to == null ? null : new[] { to };
            return ActionSend(tos);
        }

        public MMSSend ActionSend(string[] to)
        {
            var action = new MMSSend();
            action.Proxy(proxy);
            action.SetTo(to);
            return action;
        }
    }
}

public static class MMSFeatureRegister
{
    public static MMSFactory MMS(this Features features)
    {
        return new MMSFactory(features.Client, features.Proxy);
    }
}
