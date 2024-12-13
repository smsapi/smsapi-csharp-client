namespace SMSApi.Api.Response.Subusers;

public readonly record struct SubuserDetails
{
    public readonly bool Active;

    public readonly string Description;
    
    public readonly string Id;

    public readonly UserPoints Points;

    public readonly string Username;
}

public readonly record struct UserPoints
{
    public readonly double FromAccount;

    public readonly double PerMonth;

    public UserPoints(double fromAccount, double perMonth)
    {
        FromAccount = fromAccount;
        PerMonth = perMonth;
    }
}
