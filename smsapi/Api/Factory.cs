
namespace SMSApi.Api 
{
    public abstract class Factory
    {
        protected Client client;
        protected IProxy proxy;

        public Factory()
        {
            proxy = new ProxyHTTP("https://api.smsapi.pl/api/");
        }

        public Factory(Client client)
        {
            Client(client);
            proxy = new ProxyHTTP("https://api.smsapi.pl/api/");
        }

        public Factory(Client client, IProxy proxy) : this(client)
        {
            this.proxy = proxy;
        }

        public void Client(Client client)
        {
            this.client = client;
        }

        public void Proxy(IProxy proxy)
        {
            this.proxy = proxy;
        }
    }
}
