using SMSApi.Api.Response.Subusers;

namespace SMSApi.Api.Action.Subusers;

public class GetSubuser : Action<SubuserDetails>
{
    private readonly string _userId;

    public GetSubuser(string userId)
    {
        _userId = userId;
    }

    protected override RequestMethod Method => RequestMethod.GET;

    protected override string Uri() => $"subusers/{_userId}";

    protected override ApiType ApiType() => Action.ApiType.Rest;
}
