using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;

namespace smsapiTests
{
    [TestClass]
    public class MmsTest : TestBase
    {
        private MMSFactory _factory;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new MMSFactory(_client, _proxyAddress);
        }

        [TestMethod]
        public void TestSendGetDelete()
        {
            var sendResponse =
                _factory.ActionSend()
                    .SetSubject("test subject")
                    .SetSmil("<smil><head><layout><root-layout height=\"600\" width=\"425\"/><region id=\"Image\" top=\"0\" left=\"0\" height=\"100%\" width=\"100%\" fit=\"meet\"/></layout></head><body><par dur=\"5000ms\"><img src=\"https://assets.smsapi.pl/img/mms.jpg\" region=\"Image\"></img></par></body></smil>")
                    .SetTo(_validTestNumber)
                    .SetDateSent(DateTime.Now.AddHours(2))
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
