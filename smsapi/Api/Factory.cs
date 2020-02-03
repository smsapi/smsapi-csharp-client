
namespace SMSApi.Api 
{
    public abstract class Factory
    {
        protected IClient client;
        protected Proxy proxy;

        public Factory()
        {
            Proxy(new ProxyHTTP("https://api.smsapi.pl/api/"));
        }

        public Factory(IClient client)
        {
            Client(client);
            Proxy(new ProxyHTTP("https://api.smsapi.pl/api/"));
        }

        public Factory(IClient client, Proxy proxy) : this(client)
        {
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
