using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Tests;
using System;
using System.Configuration;

namespace smsapiTests
{
    [TestClass]
    public class HlrTest
    {
        Proxy proxy;
        IClient client;
        HLRFactory hlrFactory;
        String validTestNumber;

        [TestInitialize]
        public void SetUp()
        {
            var authorizationType = ConfigurationManager.AppSettings["authorizationType"];
            if (authorizationType == AuthorizationType.basic.ToString())
            {
                var basicClient = new Client(ConfigurationManager.AppSettings["username"]);
                basicClient.SetPasswordHash(ConfigurationManager.AppSettings["password"]);
                client = basicClient;
            }
            else if (authorizationType == AuthorizationType.oauth.ToString())
            {
                client = new ClientOAuth(ConfigurationManager.AppSettings["oauthToken"]);
            }

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
