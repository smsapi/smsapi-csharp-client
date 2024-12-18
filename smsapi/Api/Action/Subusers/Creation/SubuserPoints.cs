namespace SMSApi.Api.Action.Subusers.Creation;

public readonly record struct SubuserPoints(double? FromAccount = null, double? PerMonth = null)
{
    public readonly double? FromAccount = FromAccount;
    public readonly double? PerMonth = PerMonth;
}
