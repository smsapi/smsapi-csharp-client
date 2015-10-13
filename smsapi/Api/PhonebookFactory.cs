using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSApi.Api
{
    [Obsolete("use ContactsFactory instead")]
    public class PhonebookFactory : Factory
    {
        public PhonebookFactory() : base() { }
        public PhonebookFactory(Client client) : base(client) { }

        public SMSApi.Api.Action.PhonebookContactAdd ActionContactAdd(string number = null)
        {
            var action = new SMSApi.Api.Action.PhonebookContactAdd();

            action.Client(client);
            action.Proxy(proxy);

            action.SetNumber(number);

            return action;
        }

        public SMSApi.Api.Action.PhonebookContactGet ActionContactGet(string number = null)
        {
            var action = new SMSApi.Api.Action.PhonebookContactGet();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public SMSApi.Api.Action.PhonebookContactEdit ActionContactEdit(string number = null)
        {
            var action = new SMSApi.Api.Action.PhonebookContactEdit();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public SMSApi.Api.Action.PhonebookContactDelete ActionContactDelete(string number = null)
        {
            var action = new SMSApi.Api.Action.PhonebookContactDelete();

            action.Client(client);
            action.Proxy(proxy);

            action.Number(number);

            return action;
        }

        public SMSApi.Api.Action.PhonebookContactList ActionContactList()
        {
            var action = new SMSApi.Api.Action.PhonebookContactList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }

        public SMSApi.Api.Action.PhonebookGroupAdd ActionGroupAdd(string name = null)
        {
            var action = new SMSApi.Api.Action.PhonebookGroupAdd();

            action.Client(client);
            action.Proxy(proxy);

            action.SetName(name);

            return action;
        }

        public SMSApi.Api.Action.PhonebookGroupEdit ActionGroupEdit(string name = null)
        {
            var action = new SMSApi.Api.Action.PhonebookGroupEdit();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public SMSApi.Api.Action.PhonebookGroupGet ActionGroupGet(string name = null)
        {
            var action = new SMSApi.Api.Action.PhonebookGroupGet();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public SMSApi.Api.Action.PhonebookGroupDelete ActionGroupDelete(string name = null)
        {
            var action = new SMSApi.Api.Action.PhonebookGroupDelete();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public SMSApi.Api.Action.PhonebookGroupList ActionGroupList()
        {
            var action = new SMSApi.Api.Action.PhonebookGroupList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }
    }
}
