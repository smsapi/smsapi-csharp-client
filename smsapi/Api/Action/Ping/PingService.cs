using SMSApi.Api.Response.Ping;

namespace SMSApi.Api.Action.Ping;

public class PingService : Action<PingServiceResponse>
{
    protected override RequestMethod Method => RequestMethod.GET;

    protected override string Uri() => "ping";

    protected override ApiType ApiType() => Action.ApiType.Rest;
}
