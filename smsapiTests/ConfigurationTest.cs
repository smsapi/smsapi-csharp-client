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
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

            Assert.IsNotNull(username);
            Assert.AreNotEqual("", username);
            Assert.IsNotNull(password);
            Assert.AreNotEqual("", password);
            Assert.IsNotNull(baseUrl);
            Assert.AreNotEqual("", baseUrl);
        }
    }
}