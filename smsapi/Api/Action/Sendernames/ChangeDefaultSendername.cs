using SMSApi.Api.Response.Sendernames;

namespace SMSApi.Api.Action.Sendernames;

public sealed class ChangeDefaultSendername : Action<ChangeDefaultSendernameResult>
{
    private string _sender;

    public ChangeDefaultSendername(string sender)
    {
        _sender = sender;
    }

    protected override RequestMethod Method => RequestMethod.POST;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override ActionContentType ContentType => ActionContentType.Json;

    protected override string Uri()
    {
        return $"sms/sendernames/{_sender}/commands/make_default";
    }
}
