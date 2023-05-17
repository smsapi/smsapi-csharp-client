using RestSharp.Authenticators;

namespace SMSApi.Api
{
    public interface IClient
    {
        IAuthenticator Authenticator { get; }
        
        string GetClientAgent();
    }
}
