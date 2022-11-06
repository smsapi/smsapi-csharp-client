namespace SMSApi.Api
{
    public interface IClient
    {
        string GetAuthenticationHeader();
        string GetClientAgentHeader();
    }
}
