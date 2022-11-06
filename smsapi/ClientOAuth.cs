using System;

namespace SMSApi.Api
{
    public class ClientOAuth : ClientBase,
        IClient
    {
        public ClientOAuth(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }

            Token = token;
        }

        public string Token { get; }

        public override string GetAuthenticationHeader()
        {
            return "Bearer " + Token;
        }
    }
}
