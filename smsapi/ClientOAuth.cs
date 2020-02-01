using System;
using System.Text;

namespace SMSApi.Api
{
    public class ClientOAuth : IClient
    {
        public string Token { get; }

        public ClientOAuth(string token)
        {
            Token = token;
        }

        public string GetAuthenticationHeader()
        {
            return "Bearer " + Convert.ToBase64String(Encoding.UTF8.GetBytes(Token));
        }
    }
}
