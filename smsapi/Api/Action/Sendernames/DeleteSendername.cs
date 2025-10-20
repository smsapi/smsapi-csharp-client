using SMSApi.Api.Response.Sendernames;

namespace SMSApi.Api.Action.Sendernames;

public sealed class DeleteSendername : Action<DeleteSendernameResult>
{
    private string _sender;

    public DeleteSendername(string sender)
    {
        _sender = sender;
    }

    protected override RequestMethod Method => RequestMethod.DELETE;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override ActionContentType ContentType => ActionContentType.Json;

    protected override string Uri()
    {
        return $"sms/sendernames/{_sender}";
    }
}
