using SMSApi.Api.Action.Subusers.Creation;

namespace smsapiTests.Unit.Action.Subusers.Fixture;

public static class SubuserCredentialsMother
{
    public static SubuserCredentials Any()
    {
        return new SubuserCredentials("any", "any", "any");
    }
}
