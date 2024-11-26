using SMSApi.Api.Response.OptOut;

namespace SMSApi.Api.Action.OptOut;

public sealed class GetOptOutSettings : Action<OptOutSettings>
{
    protected override RequestMethod Method => RequestMethod.GET;
    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return "opt_outs/settings";
    }
}
