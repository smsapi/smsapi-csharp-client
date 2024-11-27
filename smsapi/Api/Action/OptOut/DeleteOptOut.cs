using SMSApi.Api.Response.OptOut;

namespace SMSApi.Api.Action.OptOut;

public sealed class DeleteOptOut : Action<OptOutDeletionResponse>
{
    private readonly string _optOutId;

    public DeleteOptOut(string optOutId)
    {
        _optOutId = optOutId;
    }

    protected override RequestMethod Method => RequestMethod.DELETE;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return $"opt_outs/{_optOutId}";
    }
}
