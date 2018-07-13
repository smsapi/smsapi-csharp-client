namespace SMSApi.Api
{
    public class SMSFactory : Factory
    {
        public SMSFactory() : base() { }
        public SMSFactory(Client client) : base(client) { }

        public SMSFactory(Client client, Proxy proxy) : base(client, proxy) { }

        public Action.SMSDelete ActionDelete(string id = null)
        {
            var action = new Action.SMSDelete();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public Action.SMSGet ActionGet(string id = null)
        {
            var action = new Action.SMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Id(id);

            return action;
        }

        public Action.SMSGet ActionGet(string[] id)
        {
            var action = new Action.SMSGet();

            action.Client(client);
            action.Proxy(proxy);
            action.Ids(id);

            return action;
        }

        public Action.SMSSend ActionSend(string to = null, string text = null)
        {
            var tos = ( to == null ? null : new[] { to } );
            return ActionSend(tos, text);
        }

        public Action.SMSSend ActionSend(string[] to, string text = null)
        {
            var action = new Action.SMSSend();
            action.Client(client);
            action.Proxy(proxy);
            action.SetTo(to);
            action.SetText(text);

            return action;
        }
    }
}
