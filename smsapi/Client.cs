using System.Security.Cryptography;
using System.Text;

namespace SMSApi.Api
{
    public class Client
    {
        private string _username;
        private string _password;

        public Client(string username)
        {
            SetUsername(username);
        }

        public void SetUsername(string username) => _username = username;

        public void SetPasswordHash(string password) => _password = password;

        public void SetPasswordRAW(string password)
        {
            var hash = new StringBuilder();

            var md5 = MD5.Create();
            var hashbin = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            foreach (byte h in hashbin)
            {
                hash.Append(h.ToString("x2"));
            }

            SetPasswordHash(hash.ToString());
        }

        public string GetUsername() => _username;

        public string GetPassword() => _password;
    }
}
