using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;
using System.Configuration;

namespace smsapiTests
{
    [TestClass]
    public class HlrTest
    {
        Proxy proxy;
        Client client;
        HLRFactory hlrFactory;
        String validTestNumber;

        [TestInitialize]
        public void SetUp()
        {
            client = new Client(ConfigurationManager.AppSettings["username"]);
            client.SetPasswordHash(ConfigurationManager.AppSettings["password"]);

            proxy = new ProxyHTTP(ConfigurationManager.AppSettings["baseUrl"]);

            hlrFactory = new HLRFactory(client, proxy);

            validTestNumber = ConfigurationManager.AppSettings["validTestNumber"];
        }

        [TestMethod]
        public void TestCheckNumber()
        {
            var response = hlrFactory.ActionCheckNumber(validTestNumber).Execute();

            Assert.AreEqual(1, response.List.Count);
            Assert.IsNotNull(response.List[0].ID);
        }
    }
}
