using System;
using System.Security.Cryptography;
using System.Text;
using RestSharp.Authenticators;

namespace SMSApi.Api
{
    [Obsolete("Basic authentication is deprecated, please use ClientOAuth instead")]
    public class Client : ClientBase
    {
        public Client(string username)
        {
            SetUsername(username);
        }

        public Client(string username, string passwordHash)
        {
            SetUsername(username);
            SetPasswordHash(passwordHash);
        }

        private string _password;
        private string _username;

        public override IAuthenticator Authenticator => new HttpBasicAuthenticator(_username, _password);


        public void SetPasswordHash(string password)
        {
            _password = password;
        }

        public void SetPasswordRAW(string password)
        {
            var hash = new StringBuilder();

            var md5 = MD5.Create();
            var hashbin = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (var i = 0; i < hashbin.Length; i++) hash.Append(hashbin[i].ToString("x2"));

            SetPasswordHash(hash.ToString());
        }

        public void SetUsername(string username)
        {
            _username = username;
        }
    }
}
