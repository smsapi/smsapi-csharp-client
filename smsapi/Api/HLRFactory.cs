using System;
using SMSApi.Api;
using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public class HLRFactory : Factory
    {
        public HLRFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
            : base(address)
        { }

        public HLRFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
            : base(client, address)
        { }

        public HLRFactory(IClient client, Proxy proxy)
            : base(client, proxy)
        { }

        [Obsolete($"Use {nameof(Lookup)} instead", false)]
        public HLRCheckNumber ActionCheckNumber(string number = null)
        {
            var action = new HLRCheckNumber();
            action.Proxy(proxy);
            action.SetNumber(number);
            return action;
        }
        
        public Lookup Lookup(string number)
        {
            var action = new Lookup(number);
            
            action.Proxy(proxy);
            
            return action;
        }
    }
}

public static class HlrFeatureRegister
{
    public static HLRFactory HLR(this Features features)
    {
        return new HLRFactory(features.Client, features.Proxy);
    }
}
