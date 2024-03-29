﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;
using SMSApi.Api.Response.ResponseResolver;

namespace smsapiTests
{
    [TestClass]
    public class SenderTest : TestBase
    {
        private SenderFactory _factory;
        private string _testName = "testName";

        [TestMethod]
        public void Add_Delete()
        {
            ErrorAwareResponse addResponse = _factory.ActionAdd(_testName).Execute();
            Assert.IsFalse(addResponse.IsError(), addResponse.ErrorMessage);

            ErrorAwareResponse deleteResponse = _factory.ActionDelete(_testName).Execute();
            Assert.IsFalse(deleteResponse.IsError(), deleteResponse.ErrorMessage);
        }

        [TestMethod]
        public void List_Delete()
        {
            Array<Sender> senders = _factory.ActionList().Execute();
            foreach (Sender sender in senders.List)
            {
                Assert.IsTrue(sender.Name.Length > 0);

                if (_testName.Equals(sender.Name))
                {
                    _factory.ActionDelete(sender.Name).Execute();
                }
            }
        }

        [TestMethod]
        public void SetDefault()
        {
            Array<Sender> senders = _factory.ActionList().Execute();
            foreach (Sender sender in senders.List)
            {
                if ("ACTIVE".Equals(sender.Status) && !"Test".Equals(sender.Name))
                {
                    _factory.ActionSetDefault(sender.Name).Execute();
                }
            }
        }

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new SenderFactory(_client, _proxyAddress);
        }
    }
}
