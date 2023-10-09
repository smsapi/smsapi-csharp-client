using System;
using System.Collections.Generic;

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

        public override KeyValuePair<string, string> DefaultRequestHeaders =>
            KeyValuePair.Create("Authorization", $"Bearer {_token}");
    }
}
