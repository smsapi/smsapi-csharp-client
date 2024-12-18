namespace SMSApi.Api.Action.Subusers.Creation;

public readonly record struct SubuserCredentials(string Username, string Password, string ApiPassword)
{
    public readonly string Username = Username;
    public readonly string Password = Password;
    public readonly string ApiPassword = ApiPassword;
}
