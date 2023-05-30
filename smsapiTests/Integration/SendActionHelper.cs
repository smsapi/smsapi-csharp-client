using System;
using SMSApi.Api;

namespace smsapiTests.Integration;

public static class SendActionHelper
{
    public static void SendAnySms(SMSFactory smsFactory)
    {
        try
        {
            smsFactory.ActionSend("48500100100", "any").Execute();
        }
        catch (MissingMethodException)
        {
        }
    }
    
    public static void SendAnySms(Proxy proxy)
    {
        var client = new ClientOAuth("any");
        var smsFactory = new SMSFactory(client, proxy);
        
        SendAnySms(smsFactory);
    }
}
