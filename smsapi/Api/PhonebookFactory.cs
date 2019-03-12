using System;

namespace SMSApi.Api
{
    [Obsolete("use ContactsFactory instead")]
    public class PhonebookFactory : Factory
    {
        public PhonebookFactory()
        { }
        public PhonebookFactory(Client client) : base(client) { }
        public PhonebookFactory(Client client, IProxy proxy) : base(client, proxy) { }

        public Action.PhonebookContactAdd ActionContactAdd(string number = null)
        {
            var action = new Action.PhonebookContactAdd();

            action.Client(client);
            action.Proxy(proxy);

            action.SetNumber(number);

            return action;
        }

        public Action.PhonebookContactGet ActionContactGet(string number = null)
        {
            var action = new Action.PhonebookContactGet();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public Action.PhonebookContactEdit ActionContactEdit(string number = null)
        {
            var action = new Action.PhonebookContactEdit();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public Action.PhonebookContactDelete ActionContactDelete(string number = null)
        {
            var action = new Action.PhonebookContactDelete();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public Action.PhonebookContactList ActionContactList()
        {
            var action = new Action.PhonebookContactList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }

        public Action.PhonebookGroupAdd ActionGroupAdd(string name = null)
        {
            var action = new Action.PhonebookGroupAdd();

            action.Client(client);
            action.Proxy(proxy);

            action.SetName(name);

            return action;
        }

        public Action.PhonebookGroupEdit ActionGroupEdit(string name = null)
        {
            var action = new Action.PhonebookGroupEdit();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupGet ActionGroupGet(string name = null)
        {
            var action = new Action.PhonebookGroupGet();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupDelete ActionGroupDelete(string name = null)
        {
            var action = new Action.PhonebookGroupDelete();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public Action.PhonebookGroupList ActionGroupList()
        {
            var action = new Action.PhonebookGroupList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }
    }
}
