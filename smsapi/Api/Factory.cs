
using System.Collections.Generic;

namespace SMSApi.Api 
{
    public abstract class Factory
    {
        private static Dictionary<ProxyAddress, string> _addresses =
            new Dictionary<ProxyAddress, string>
            {
                { ProxyAddress.SmsApiPl, "https://api.smsapi.pl/api/" },
                { ProxyAddress.SmsApiCom, "https://api.smsapi.com/api/" }
            };

        protected IClient client;
        protected Proxy proxy;

        public Factory(ProxyAddress address = ProxyAddress.SmsApiPl)
        {
            Proxy(new ProxyHTTP(_addresses[address]));
        }

        public Factory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl) 
            : this(address)
        {
            Client(client);
        }

        public Factory(IClient client, Proxy proxy) 
        {
            Client(client);
            Proxy(proxy);
        }

        public void Client(IClient client)
        {
            this.client = client;
            if (proxy != null)
            {
                proxy.Authentication(client);
            }
        }

        public void Proxy(Proxy proxy)
        {
            this.proxy = proxy;
            if (proxy != null)
            {
                proxy.Authentication(client);
            }
        }
    }
}
