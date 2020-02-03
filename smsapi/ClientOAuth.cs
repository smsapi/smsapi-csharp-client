using System;
using System.Text;

namespace SMSApi.Api
{
    public class ClientOAuth : IClient
    {
        public string Token { get; }

        public ClientOAuth(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            Token = token;
        }

        public string GetAuthenticationHeader()
        {
            return "Bearer " + Token;
        }
    }
}
