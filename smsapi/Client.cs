using System.Security.Cryptography;
using System.Text;

namespace SMSApi.Api
{
    public class Client
    {
        protected string username;
        protected string password;

        public Client(string username)
        {
            SetUsername(username);
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public void SetPasswordHash(string password)
        {
            this.password = password;
        }

        public void SetPasswordRAW(string password)
        {
            StringBuilder hash = new StringBuilder();

            MD5 md5 = MD5.Create();
            byte[] hashbin = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < hashbin.Length; i++)
            {
                hash.Append(hashbin[i].ToString("x2"));
            }

            SetPasswordHash(hash.ToString());
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }
    }
}
