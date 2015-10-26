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
        protected MMSFactory mmsFactory;
        protected VMSFactory vmsFactory;
        protected SenderFactory senderFactory;
        protected UserFactory userFactory;
        protected PhonebookFactory phonebookFactory;
        protected String validTestNumber;

        [TestInitialize]
        public void SetUp()
        {
            client = new Client(ConfigurationManager.AppSettings["username"]);
            client.SetPasswordHash(ConfigurationManager.AppSettings["password"]);

            proxy = new ProxyHTTP(ConfigurationManager.AppSettings["baseUrl"]);

            smsFactory = new SMSFactory(client, proxy);
            mmsFactory = new MMSFactory(client, proxy);
            vmsFactory = new VMSFactory(client, proxy);
            senderFactory = new SenderFactory(client, proxy);
            userFactory = new UserFactory(client, proxy);
            phonebookFactory = new PhonebookFactory(client, proxy);

            validTestNumber = ConfigurationManager.AppSettings["validTestNumber"];
        }
    }
}
