using SMSApi.Api.Response.ResponseResolver;

namespace SMSApi.Api.Response.MFA;

public class MFACreationResponse : IResponseCodeAwareResolver
{
    public readonly string Code;

    public readonly string From;

    public readonly string Id;

    public readonly string PhoneNumber;
}
