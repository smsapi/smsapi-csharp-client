using System.Runtime.Serialization;

namespace SMSApi.Api.Response.Subusers;

[DataContract]
public readonly record struct SubuserDetails
{
    [DataMember(Name = "active")] public readonly bool Active;

    [DataMember(Name = "description")] public readonly string Description;
    
    [DataMember(Name = "id")] public readonly string Id;

    [DataMember(Name = "points")] public readonly UserPoints Points;

    [DataMember(Name = "username")] public readonly string Username;
}

[DataContract]
public readonly record struct UserPoints(double FromAccount, double PerMonth)
{
    [DataMember(Name = "from_account")] public readonly double FromAccount = FromAccount;

    [DataMember(Name = "per_month")] public readonly double PerMonth = PerMonth;
}
