using System;
using SMSApi.Api.Response.OptOut;

namespace SMSApi.Api.Action.OptOut;

public class DeleteOptOut : Action<OptOutDeletionResponse>
{
    private readonly string _optOutId;

    public DeleteOptOut(string optOutId)
    {
        _optOutId = optOutId;
    }
    
    public DeleteOptOut(Guid optOutId)
    {
        _optOutId = optOutId.ToString();
    }

    protected override RequestMethod Method => RequestMethod.DELETE;

    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return $"opt_outs/{_optOutId}";
    }
}
