using SMSApi.Api.Action.MFA;

namespace SMSApi.Api;

public class MFAFactory : Factory
{
    public MFAFactory(ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(address)
    {
    }

    public MFAFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiIo)
        : base(client, address)
    {
    }

    public MFAFactory(IClient client, Proxy proxy)
        : base(client, proxy)
    {
    }

    public CreateMFACode CreateMfaCode(string phoneNumber)
    {
        var action = new CreateMFACode(phoneNumber);
        action.Proxy(proxy);

        return action;
    }

    public VerifyMFACode VerifyMfaCode(string phoneNumber, string code)
    {
        var action = new VerifyMFACode(phoneNumber, code);
        action.Proxy(proxy);

        return action;
    }
}

public static class MFAFeatureRegister
{
    public static MFAFactory MFA(this Features features)
    {
        return new MFAFactory(features.Client, features.Proxy);
    }
}
