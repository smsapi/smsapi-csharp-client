using System.Collections.Specialized;
using SMSApi.Api.Response.MFA;

namespace SMSApi.Api.Action.MFA;

public class CreateMFACode : Action<MFACreationResponse>
{
    private readonly string phoneNumber;
    private string content;
    private bool fast;
    private string from;

    public CreateMFACode(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }

    protected override RequestMethod Method => RequestMethod.POST;

    public CreateMFACode AsFast()
    {
        fast = true;

        return this;
    }

    public CreateMFACode FromSendername(string sendername)
    {
        from = sendername;

        return this;
    }

    public CreateMFACode WithContent(string content)
    {
        this.content = content;

        return this;
    }

    protected override ApiType ApiType()
    {
        return Action.ApiType.Rest;
    }

    protected override string Uri()
    {
        return "mfa/codes";
    }

    protected override NameValueCollection Values()
    {
        var parameters = new NameValueCollection { { "phone_number", phoneNumber } };

        if (content != null)
            parameters.Add("content", content);

        if (fast)
            parameters.Add("fast", "1");

        if (from != null)
            parameters.Add("from", from);

        return parameters;
    }
}
