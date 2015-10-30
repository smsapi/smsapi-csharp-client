using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;
using System.Configuration;

namespace smsapiTests
{
    public abstract class TestBase
    {
        protected Proxy proxy;
        protected Client client;
        protected SMSFactory smsFactory;
        protected SenderFactory senderFactory;
        protected UserFactory userFactory;
        protected PhonebookFactory phonebookFactory;
        protected ContactsFactory contactsFactory;
        protected string validTestNumber;
        protected string subUserName;

        [TestInitialize]
        public void SetUp()
        {
            client = new Client(ConfigurationManager.AppSettings["username"]);
            client.SetPasswordHash(ConfigurationManager.AppSettings["password"]);

            proxy = new ProxyHTTP(ConfigurationManager.AppSettings["baseUrl"]);

            smsFactory = new SMSFactory(client, proxy);
            senderFactory = new SenderFactory(client, proxy);
            userFactory = new UserFactory(client, proxy);
            
            contactsFactory = new ContactsFactory(client, proxy);

            var clientLegacy = new Client(ConfigurationManager.AppSettings["usernameOldPhonebook"]);
            clientLegacy.SetPasswordHash(ConfigurationManager.AppSettings["passwordOldPhonebook"]);
            phonebookFactory = new PhonebookFactory(clientLegacy, proxy);

            subUserName = ConfigurationManager.AppSettings["subUserName"];
            validTestNumber = ConfigurationManager.AppSettings["validTestNumber"];
        }
    }
}
