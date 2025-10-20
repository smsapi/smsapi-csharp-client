using SMSApi.Api.Response.Sendernames;

namespace SMSApi.Api.Action.Sendernames;

public sealed class GetSendername : Action<Sendername>
{
    private string _sender;

    public GetSendername(string sender)
    {
        _sender = sender;
    }

    protected override RequestMethod Method => RequestMethod.GET;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return $"sms/sendernames/{_sender}";
    }
}
