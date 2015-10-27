using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;
using System.Configuration;

namespace smsapiTests
{
    [TestClass]
    public class SenderTest : TestBase
    {
        String testName = "testName";

        [TestMethod]
        public void TestList_Delete()
        {
            var senders = senderFactory.ActionList().Execute();
            foreach (var sender in senders.List)
            {
                Assert.IsTrue(sender.Name.Length > 0);

                if (testName.Equals(sender.Name))
                {
                    senderFactory.ActionDelete(sender.Name).Execute();
                }
            }
        }

        [TestMethod]
        public void TestAdd_Delete()
        {
            var addResponse = senderFactory.ActionAdd(testName).Execute();
            Assert.IsFalse(addResponse.isError(), addResponse.ErrorMessage);

            var deleteResponse = senderFactory.ActionDelete(testName).Execute();
            Assert.IsFalse(deleteResponse.isError(), deleteResponse.ErrorMessage);
        }

        [TestMethod]
        public void TestSetDefault()
        {
            var senders = senderFactory.ActionList().Execute();
            foreach (var sender in senders.List)
            {
                if ("ACTIVE".Equals(sender.Status))
                {
                    senderFactory.ActionSetDefault(sender.Name).Execute();
                }
            }
        }
    }
}
