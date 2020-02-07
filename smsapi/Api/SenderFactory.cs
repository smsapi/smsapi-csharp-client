using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSApi.Api
{
    public class SenderFactory : Factory
    {
        public SenderFactory(ProxyAddress address = ProxyAddress.SmsApiPl) 
            : base(address) 
        { 
        }

        public SenderFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl) 
            : base(client, address) 
        { 
        }

        public SenderFactory(IClient client, Proxy proxy) 
            : base(client, proxy) 
        { 
        }

        public SMSApi.Api.Action.SenderAdd ActionAdd(string name = null)
        {
            var action = new SMSApi.Api.Action.SenderAdd();

            action.Client(client);
            action.Proxy(proxy);

            action.SetName(name);

            return action;
        }

        public SMSApi.Api.Action.SenderDelete ActionDelete(string name = null)
        {
            var action = new SMSApi.Api.Action.SenderDelete();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public SMSApi.Api.Action.SenderSetDefault ActionSetDefault(string name = null)
        {
            var action = new SMSApi.Api.Action.SenderSetDefault();

            action.Client(client);
            action.Proxy(proxy);

            action.Name(name);

            return action;
        }

        public SMSApi.Api.Action.SenderList ActionList()
        {
            var action = new SMSApi.Api.Action.SenderList();

            action.Client(client);
            action.Proxy(proxy);

            return action;
        }
    }
}
