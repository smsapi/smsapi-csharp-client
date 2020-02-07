using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;
using System.Configuration;

namespace smsapiTests
{
    [TestClass]
    public class SenderTest : TestBase
    {
        private SenderFactory _factory;
        private string _testName = "testName";

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new SenderFactory(_client, _proxyAddress);
        }

        [TestMethod]
        public void List_Delete()
        {
            var senders = _factory.ActionList().Execute();
            foreach (var sender in senders.List)
            {
                Assert.IsTrue(sender.Name.Length > 0);

                if (_testName.Equals(sender.Name))
                {
                    _factory.ActionDelete(sender.Name).Execute();
                }
            }
        }

        [TestMethod]
        public void Add_Delete()
        {
            var addResponse = _factory.ActionAdd(_testName).Execute();
            Assert.IsFalse(addResponse.isError(), addResponse.ErrorMessage);

            var deleteResponse = _factory.ActionDelete(_testName).Execute();
            Assert.IsFalse(deleteResponse.isError(), deleteResponse.ErrorMessage);
        }

        [TestMethod]
        public void SetDefault()
        {
            var senders = _factory.ActionList().Execute();
            foreach (var sender in senders.List)
            {
                if ("ACTIVE".Equals(sender.Status) && !"Test".Equals(sender.Name))
                {
                    _factory.ActionSetDefault(sender.Name).Execute();
                }
            }
        }
    }
}
