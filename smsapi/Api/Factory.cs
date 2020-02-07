
using System.Collections.Generic;

namespace SMSApi.Api 
{
    public abstract class Factory
    {
        private static Dictionary<ProxyAddress, string> _addresses =
            new Dictionary<ProxyAddress, string>
            {
                { ProxyAddress.SmsApiPl, "https://api.smsapi.pl/" },
                { ProxyAddress.BackupSmsApiPl, "https://api2.smsapi.pl/" },
                { ProxyAddress.SmsApiCom, "https://api.smsapi.com/" },
                { ProxyAddress.BackupSmsApiCom, "https://api2.smsapi.com/" }
            };

        protected IClient client;
        protected Proxy proxy;

        public Factory(ProxyAddress address = ProxyAddress.SmsApiPl)
        {
            Proxy(address);
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

        public void Proxy(ProxyAddress address)
        {
            Proxy(new ProxyHTTP(_addresses[address]));
        }
    }
}
