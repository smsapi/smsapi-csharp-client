
namespace SMSApi.Api 
{
    public abstract class Factory
    {
        protected IClient client;
        protected Proxy proxy;

        public Factory()
        {
            proxy = new ProxyHTTP("https://api.smsapi.pl/api/");
        }

        public Factory(IClient client)
        {
            Client(client);
            proxy = new ProxyHTTP("https://api.smsapi.pl/api/");
        }

        public Factory(IClient client, Proxy proxy) : this(client)
        {
            this.proxy = proxy;
        }

        public void Client(IClient client)
        {
            this.client = client;
        }

        public void Proxy(Proxy proxy)
        {
            this.proxy = proxy;
        }
    }
}
