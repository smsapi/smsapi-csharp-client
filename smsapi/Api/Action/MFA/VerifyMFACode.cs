using System.Collections.Specialized;
using SMSApi.Api.Response.MFA;

namespace SMSApi.Api.Action.MFA;

public class VerifyMFACode : Base<MFACreationResponse>
{
    private readonly string code;
    private readonly string phoneNumber;

    public VerifyMFACode(string phoneNumber, string code)
    {
        this.phoneNumber = phoneNumber;
        this.code = code;
    }

    protected override RequestMethod Method => RequestMethod.POST;


    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return "mfa/codes/verifications";
    }

    protected override NameValueCollection Values()
    {
        return new NameValueCollection { { "phone_number", phoneNumber }, { "code", code } };
    }
}
