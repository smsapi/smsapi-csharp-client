using System;
using SMSApi.Api.Action;

namespace SMSApi.Api
{
    [Obsolete("use ContactsFactory instead")]
    public class PhonebookFactory : Factory
    {
        public PhonebookFactory(ProxyAddress address = ProxyAddress.SmsApiPl)
            : base(address)
        { }

        public PhonebookFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl)
            : base(client, address)
        { }

        public PhonebookFactory(IClient client, Proxy proxy)
            : base(client, proxy)
        { }

        public PhonebookContactAdd ActionContactAdd(string number = null)
        {
            var action = new PhonebookContactAdd();

            action.Client(client);
            action.Proxy(proxy);

            action.SetNumber(number);

            return action;
        }

        public PhonebookContactDelete ActionContactDelete(string number = null)
        {
            var action = new PhonebookContactDelete();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public PhonebookContactEdit ActionContactEdit(string number = null)
        {
            var action = new PhonebookContactEdit();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public PhonebookContactGet ActionContactGet(string number = null)
        {
            var action = new PhonebookContactGet();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public PhonebookContactList ActionContactList()
        {
            var action = new PhonebookContactList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }

        public PhonebookGroupAdd ActionGroupAdd(string name = null)
        {
            var action = new PhonebookGroupAdd();

            action.Client(client);
            action.Proxy(proxy);

            action.SetName(name);

            return action;
        }

        public PhonebookGroupDelete ActionGroupDelete(string name = null)
        {
            var action = new PhonebookGroupDelete();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public PhonebookGroupEdit ActionGroupEdit(string name = null)
        {
            var action = new PhonebookGroupEdit();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public PhonebookGroupGet ActionGroupGet(string name = null)
        {
            var action = new PhonebookGroupGet();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public PhonebookGroupList ActionGroupList()
        {
            var action = new PhonebookGroupList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }
    }
}
