using System;
using System.Text;

namespace SMSApi.Api
{
    public class ClientOAuth : IClient
    {
        public string Token { get; private set; }

        public ClientOAuth(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }

            Token = token;
        }

        public string GetAuthenticationHeader()
        {
            return "Bearer " + Token;
        }
    }
}
