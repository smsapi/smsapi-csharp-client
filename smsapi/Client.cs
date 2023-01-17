using System;
using System.Security.Cryptography;
using System.Text;

namespace SMSApi.Api
{
    public class Client : ClientBase,
        IClient
    {
        protected string password;
        protected string username;

        public Client(string username)
        {
            SetUsername(username);
        }

        public override string GetAuthenticationHeader()
        {
            return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetUsername()
        {
            return username;
        }

        public void SetPasswordHash(string password)
        {
            this.password = password;
        }

        public void SetPasswordRAW(string password)
        {
            var hash = new StringBuilder();

            var md5 = MD5.Create();
            byte[] hashbin = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < hashbin.Length; i++)
            {
                hash.Append(hashbin[i].ToString("x2"));
            }

            SetPasswordHash(hash.ToString());
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }
    }
}
