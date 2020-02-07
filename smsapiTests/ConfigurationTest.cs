using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApi.Api.Tests
{
    [TestClass()]
    public class ConfigurationTest
    {
        [TestMethod()]
        public void VerifyConfiguration()
        {
            var authorizationType = ConfigurationManager.AppSettings["authorizationType"];
            if (authorizationType == AuthorizationType.basic.ToString())
            {
                string password = ConfigurationManager.AppSettings["password"];
                Assert.IsNotNull(password);
                Assert.AreNotEqual("", password);
            }
            else if (authorizationType == AuthorizationType.oauth.ToString())
            {
                string token = ConfigurationManager.AppSettings["oauthToken"];
                Assert.IsNotNull(token);
                Assert.AreNotEqual("", token);
            }

            string username = ConfigurationManager.AppSettings["username"];
            Assert.IsNotNull(username);
            Assert.AreNotEqual("", username);

            var validTestNumber = ConfigurationManager.AppSettings["validTestNumber"];
            Assert.IsNotNull(validTestNumber);
            Assert.AreNotEqual("", validTestNumber);

            ProxyAddress proxy;
            Assert.IsTrue(Enum.TryParse(ConfigurationManager.AppSettings["addressType"], out proxy));
        }
    }
}