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
                string username = ConfigurationManager.AppSettings["username"];
                string password = ConfigurationManager.AppSettings["password"];
                Assert.IsNotNull(username);
                Assert.AreNotEqual("", username);
                Assert.IsNotNull(password);
                Assert.AreNotEqual("", password);
            }
            else if (authorizationType == AuthorizationType.oauth.ToString())
            {
                string token = ConfigurationManager.AppSettings["oauthToken"];
                Assert.IsNotNull(token);
                Assert.AreNotEqual("", token);
            }
            
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            Assert.IsNotNull(baseUrl);
            Assert.AreNotEqual("", baseUrl);
        }
    }
}