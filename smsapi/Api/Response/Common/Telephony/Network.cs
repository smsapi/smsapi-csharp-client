namespace SMSApi.Api.Response.Common.Telephony;

public readonly record struct Network
{
    public readonly string Name;
    public readonly int MNC;

    public Network(string name, int mnc)
    {
        Name = name;
        MNC = mnc;
    }
}
