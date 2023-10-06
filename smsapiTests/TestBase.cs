using System;
using System.Configuration;
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
            string authorizationType = ConfigurationManager.AppSettings["authorizationType"];
            _username = ConfigurationManager.AppSettings["username"];

            if (authorizationType == AuthorizationType.oauth.ToString())
            {
                _client = new ClientOAuth(ConfigurationManager.AppSettings["oauthToken"]);
            }

            _proxyAddress = (ProxyAddress)Enum.Parse(
                typeof(ProxyAddress),
                ConfigurationManager.AppSettings["addressType"]);
            _validTestNumber = ConfigurationManager.AppSettings["validTestNumber"];
        }
    }
}
