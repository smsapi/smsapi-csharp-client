using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public class UserFactory : Factory
    {
        public UserFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
            : base(address)
        { }

        public UserFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
            : base(client, address)
        { }

        public UserFactory(IClient client, Proxy proxy)
            : base(client, proxy)
        { }

        public UserAdd ActionAdd()
        {
            var action = new UserAdd();
            action.Proxy(proxy);
            return action;
        }

        public UserEdit ActionEdit(string username = null)
        {
            var action = new UserEdit();
            action.Proxy(proxy);
            action.Username(username);
            return action;
        }

        public UserGet ActionGet(string username = null)
        {
            var action = new UserGet();
            action.Proxy(proxy);
            action.Username(username);
            return action;
        }

        public UserGetCredits ActionGetCredits()
        {
            var action = new UserGetCredits();
            action.Proxy(proxy);
            return action;
        }

        public UserList ActionList()
        {
            var action = new UserList();
            action.Proxy(proxy);
            return action;
        }
    }
}
