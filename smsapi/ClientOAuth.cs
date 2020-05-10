using System;
using System.Text;

namespace SMSApi.Api
{
    public class ClientOAuth : ClientBase, IClient
    {
        public string Token { get; private set; }

        public ClientOAuth(string token)
            : base()
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }

            Token = token;
        }

        public override string GetAuthenticationHeader()
        {
            return "Bearer " + Token;
        }
    }
}
