namespace SMSApi.Api.Action.Profile;

public sealed class GetProfile : Action<Response.Profile.Profile>
{
    protected override RequestMethod Method => RequestMethod.GET;
    protected override ApiType ApiType() => Action.ApiType.Rest;

    protected override string Uri()
    {
        return "profile";
    }
}
