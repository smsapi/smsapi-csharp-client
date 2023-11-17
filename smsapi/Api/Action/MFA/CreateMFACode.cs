using System.Collections.Specialized;
using SMSApi.Api.Response.MFA;

namespace SMSApi.Api.Action.MFA;

public class CreateMFACode : Action<MFACreationResponse>
{
    private readonly string _phoneNumber;
    private string _content;
    private bool _withoutPriority;
    private string _from;

    public CreateMFACode(string phoneNumber)
    {
        this._phoneNumber = phoneNumber;
    }

    protected override RequestMethod Method => RequestMethod.POST;

    public CreateMFACode WithoutPriority()
    {
        _withoutPriority = true;

        return this;
    }

    public CreateMFACode FromSendername(string sendername)
    {
        _from = sendername;

        return this;
    }

    public CreateMFACode WithContent(string content)
    {
        this._content = content;

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
        var parameters = new NameValueCollection { { "phone_number", _phoneNumber } };

        if (_content != null)
            parameters.Add("content", _content);

        if (_withoutPriority)
            parameters.Add("fast", "0");

        if (_from != null)
            parameters.Add("from", _from);

        return parameters;
    }
}
