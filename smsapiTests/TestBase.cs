using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests
{
    public abstract class TestBase
    {
        protected IClient _client;
        protected ProxyAddress _proxyAddress;
        protected string _username;
        protected string _validTestNumber;

        [TestInitialize]
        public virtual void SetUp()
        {
            var appSettings = TestConfig.AppSettings;

            string authorizationType = appSettings["authorizationType"];
            _username = appSettings["username"];

            if (authorizationType == AuthorizationType.basic.ToString())
            {
                var basicClient = new Client(_username);
                basicClient.SetPasswordHash(appSettings["password"]);
                _client = basicClient;
            }
            else if (authorizationType == AuthorizationType.oauth.ToString())
            {
                _client = new ClientOAuth(appSettings["oauthToken"]);
            }

            _proxyAddress = (ProxyAddress)Enum.Parse(
                typeof(ProxyAddress),
                appSettings["addressType"]);
            _validTestNumber = appSettings["validTestNumber"];
        }
    }
}
