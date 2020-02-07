using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Tests;
using System;
using System.Configuration;

namespace smsapiTests
{
    public abstract class TestBase
    {
        protected IClient _client;
        protected ProxyAddress _proxyAddress;
        protected string _validTestNumber;
        protected string _username;

        [TestInitialize]
        public virtual void SetUp()
        {
            var authorizationType = ConfigurationManager.AppSettings["authorizationType"];
            _username = ConfigurationManager.AppSettings["username"];

            if (authorizationType == AuthorizationType.basic.ToString())
            {
                var basicClient = new Client(_username);
                basicClient.SetPasswordHash(ConfigurationManager.AppSettings["password"]);
                _client = basicClient;
            }
            else if (authorizationType == AuthorizationType.oauth.ToString())
            {
                _client = new ClientOAuth(ConfigurationManager.AppSettings["oauthToken"]);
            }

            _proxyAddress = (ProxyAddress)Enum.Parse(typeof(ProxyAddress), ConfigurationManager.AppSettings["addressType"]);
            _validTestNumber = ConfigurationManager.AppSettings["validTestNumber"];
        }
    }
}
