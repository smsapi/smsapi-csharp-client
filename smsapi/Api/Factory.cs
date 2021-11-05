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

        protected Proxy proxy;

        private IClient client;

        protected Factory(ProxyAddress address = ProxyAddress.SmsApiPl)
        {
            Proxy(address);
        }

        protected Factory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl)
            : this(address)
        {
            Client(client);
        }

        protected Factory(IClient client, Proxy proxy)
        {
            Client(client);
            Proxy(proxy);
        }

        private void Client(IClient client)
        {
            this.client = client;
            proxy?.Authentication(client);
        }

        private void Proxy(Proxy proxy)
        {
            this.proxy = proxy;
            proxy?.Authentication(client);
        }

        private void Proxy(ProxyAddress address)
        {
            Proxy(new ProxyHTTP(_addresses[address]));
        }
    }
}
