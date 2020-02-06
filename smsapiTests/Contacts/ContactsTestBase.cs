using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
