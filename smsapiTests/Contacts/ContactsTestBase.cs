using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ContactsTestBase : TestBase
    {
        protected ContactsFactory _factory;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new ContactsFactory(_client, _proxyAddress);
        }
    }
}
