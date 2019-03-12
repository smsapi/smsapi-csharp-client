namespace SMSApi.Api
{
    public class SenderFactory : Factory
    {
        public SenderFactory()
        { }
        public SenderFactory(Client client) : base(client) { }
        public SenderFactory(Client client, IProxy proxy) : base(client, proxy) { }

        public Action.SenderAdd ActionAdd(string name = null)
        {
            var action = new Action.SenderAdd();

            action.Client(client);
            action.Proxy(proxy);

            action.SetName(name);

            return action;
        }

        public Action.SenderDelete ActionDelete(string name = null)
        {
            var action = new Action.SenderDelete();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public Action.SenderSetDefault ActionSetDefault(string name = null)
        {
            var action = new Action.SenderSetDefault();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public Action.SenderList ActionList()
        {
            var action = new Action.SenderList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }
    }
}
