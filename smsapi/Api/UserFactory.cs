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

        public SMSApi.Api.Action.UserGetCredits ActionGetCredits()
        {
            var action = new SMSApi.Api.Action.UserGetCredits();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }

        public SMSApi.Api.Action.UserAdd ActionAdd()
        {
            var action = new SMSApi.Api.Action.UserAdd();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }

        public SMSApi.Api.Action.UserEdit ActionEdit(string username = null)
        {
            var action = new SMSApi.Api.Action.UserEdit();

            action.Client(client);
            action.Proxy(proxy);

            action.Username(username);

            return action;
        }

        public SMSApi.Api.Action.UserGet ActionGet(string username = null)
        {
            var action = new SMSApi.Api.Action.UserGet();

            action.Client(client);
            action.Proxy(proxy);

            action.Username(username);

            return action;
        }

        public SMSApi.Api.Action.UserList ActionList()
        {
            var action = new SMSApi.Api.Action.UserList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }
    }
}
