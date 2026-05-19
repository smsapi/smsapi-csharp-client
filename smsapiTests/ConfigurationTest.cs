using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void VerifyConfiguration()
        {
            var appSettings = TestConfig.AppSettings;

            string authorizationType = appSettings["authorizationType"];
            if (authorizationType == AuthorizationType.basic.ToString())
            {
                string password = appSettings["password"];
                Assert.IsNotNull(password);
                Assert.AreNotEqual("", password);
            }
            else if (authorizationType == AuthorizationType.oauth.ToString())
            {
                string token = appSettings["oauthToken"];
                Assert.IsNotNull(token);
                Assert.AreNotEqual("", token);
            }

            string username = appSettings["username"];
            Assert.IsNotNull(username);
            Assert.AreNotEqual("", username);

            string validTestNumber = appSettings["validTestNumber"];
            Assert.IsNotNull(validTestNumber);
            Assert.AreNotEqual("", validTestNumber);

            ProxyAddress proxy;
            Assert.IsTrue(Enum.TryParse(appSettings["addressType"], out proxy));
        }
    }
}
