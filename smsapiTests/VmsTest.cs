using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;

namespace smsapiTests
{
    [TestClass]
    public class VmsTest : TestBase
    {
        private VMSFactory _factory;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new VMSFactory(_client, _proxyAddress);
        }

        [TestMethod]
        public void TestSendGetDelete()
        {
            DateTime date = DateTime.Now;
            if (date.Hour > 21 || date.Hour < 8)
            {
                date = date.AddHours(12);
            }

            var sendResponse =
                _factory.ActionSend()
                    .SetTTS("test message")
                    .SetTo(_validTestNumber)
                    .SetDateSent(date)
                    .SetTry(4)
                    .SetTryInterval(300)
                    .Execute();

            Assert.AreEqual(1, sendResponse.Count);
            Assert.IsTrue(sendResponse.List[0].Points > 0, "Points must be greather then 0");

            string[] ids = new string[sendResponse.Count];

            for (int i = 0, l = 0; i < sendResponse.List.Count; i++)
            {
                ids[l] = sendResponse.List[i].ID;
                l++;
            }

            System.Console.WriteLine("Get:");
            var getResponse =
                _factory.ActionGet()
                    .Ids(ids)
                    .Execute();

            Assert.AreEqual(sendResponse.Count, getResponse.Count);
            Assert.AreEqual(_validTestNumber, getResponse.List[0].Number);
            Assert.AreEqual(sendResponse.List[0].ID, getResponse.List[0].ID);
            Assert.AreEqual(sendResponse.List[0].IDx, getResponse.List[0].IDx);
            Assert.AreEqual(sendResponse.List[0].Points, getResponse.List[0].Points);
            Assert.AreEqual(sendResponse.List[0].Status, getResponse.List[0].Status);

            var deletedResponse =
                _factory
                    .ActionDelete()
                        .Ids(ids)
                        .Execute();

            Assert.AreEqual(sendResponse.Count, deletedResponse.Count);
        }
    }
}
