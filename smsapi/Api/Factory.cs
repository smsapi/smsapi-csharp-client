
namespace SMSApi.Api 
{
    public abstract class Factory
    {
        protected Client client;
        protected Proxy proxy;

        public Factory()
        {
            proxy = new ProxyHTTP("http://smsapi.local/api/");
        }

        public Factory(Client client)
        {
            Client(client);
            proxy = new ProxyHTTP("http://smsapi.local/api/");
        }

        public void Client(Client client)
        {
            this.client = client;
        }

        public void Proxy(Proxy proxy)
        {
            this.proxy = proxy;
        }
    }
}
