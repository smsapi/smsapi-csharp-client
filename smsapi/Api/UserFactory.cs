using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSApi.Api
{
    public class UserFactory : Factory
    {
        public UserFactory() : base() { }
        public UserFactory(Client client) : base(client) { }
        public UserFactory(Client client, Proxy proxy) : base(client, proxy) { }

        public Action.UserGetCredits ActionGetCredits()
        {
            var action = new Action.UserGetCredits();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }

        public Action.UserAdd ActionAdd()
        {
            var action = new Action.UserAdd();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }

        public Action.UserEdit ActionEdit(string username = null)
        {
            var action = new Action.UserEdit();

            action.Client(client);
            action.Proxy(proxy);

            action.Username(username);

            return action;
        }

        public Action.UserGet ActionGet(string username = null)
        {
            var action = new Action.UserGet();

            action.Client(client);
            action.Proxy(proxy);

            action.Username(username);

            return action;
        }

        public Action.UserList ActionList()
        {
            var action = new Action.UserList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }
    }
}
