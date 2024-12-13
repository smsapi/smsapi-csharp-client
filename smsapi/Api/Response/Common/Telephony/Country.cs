namespace SMSApi.Api.Response.Common.Telephony;

public readonly record struct Country
{
    public readonly string Name;
    public readonly int MCC;

    public Country(string name, int mcc)
    {
        Name = name;
        MCC = mcc;
    }
}
