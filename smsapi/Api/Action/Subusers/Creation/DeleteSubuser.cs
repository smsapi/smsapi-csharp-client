using SMSApi.Api.Response.Subusers;

namespace SMSApi.Api.Action.Subusers.Creation;

public sealed class DeleteSubuser : Action<SubuserDeletionResult>
{
    private readonly string _userId;

    public DeleteSubuser(string userId)
    {
        _userId = userId;
    }

    protected override RequestMethod Method => RequestMethod.DELETE;

    protected override string Uri() => $"subusers/{_userId}";

    protected override ApiType ApiType() => Action.ApiType.Rest;
}
