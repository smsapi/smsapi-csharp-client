using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Tests;
using System;
using System.Configuration;

namespace smsapiTests
{
    public abstract class TestBase
    {
        protected Proxy proxy;
        protected IClient client;
        protected SMSFactory smsFactory;
        protected MMSFactory mmsFactory;
        protected VMSFactory vmsFactory;
        protected SenderFactory senderFactory;
        protected UserFactory userFactory;
        protected PhonebookFactory phonebookFactory;
        protected ContactsFactory contactsFactory;
        protected string validTestNumber;
        protected string subUserName;

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

            smsFactory = new SMSFactory(client, proxy);
            mmsFactory = new MMSFactory(client, proxy);
            vmsFactory = new VMSFactory(client, proxy);
            senderFactory = new SenderFactory(client, proxy);
            userFactory = new UserFactory(client, proxy);
            contactsFactory = new ContactsFactory(client, proxy);

            subUserName = ConfigurationManager.AppSettings["subUserName"];
            validTestNumber = ConfigurationManager.AppSettings["validTestNumber"];
        }
    }
}
