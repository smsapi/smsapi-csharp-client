using System;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace SMSApi.Api
{
    public class ClientOAuth : ClientBase
    {
        private readonly string _token;

        public ClientOAuth(string token)
        {
            if (string.IsNullOrEmpty(token)) throw new ArgumentNullException(nameof(token));

            _token = token;
        }

        public override IAuthenticator Authenticator =>
            new OAuth2AuthorizationRequestHeaderAuthenticator(_token, "Bearer");
    }
}
