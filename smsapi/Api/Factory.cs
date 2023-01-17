namespace SMSApi.Api
{
    public abstract class Factory
    {
        protected Proxy proxy;

        private IClient client;

        protected Factory(ProxyAddress address = ProxyAddress.SmsApiIo)
        {
            Proxy(address);
        }

        protected Factory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
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
            Proxy(new ProxyHTTP(address.GetUrl()));
        }
    }
}
