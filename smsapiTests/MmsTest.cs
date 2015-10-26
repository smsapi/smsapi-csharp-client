using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace smsapiTests
{
    [TestClass]
    public class MmsTest : TestBase
    {
        [TestMethod]
        public void TestSendGetDelete()
        {
            var sendResponse =
                mmsFactory.ActionSend()
                    .SetSubject("test subject")
                    .SetSmil("<smil><head><layout><root-layout height=\"600\" width=\"425\"/><region id=\"Image\" top=\"0\" left=\"0\" height=\"100%\" width=\"100%\" fit=\"meet\"/></layout></head><body><par dur=\"5000ms\"><img src=\"https://www.smsapi.pl/assets/img/mms.jpg\" region=\"Image\"></img></par></body></smil>")
                    .SetTo(validTestNumber)
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
                mmsFactory.ActionGet()
                    .Ids(ids)
                    .Execute();

            Assert.AreEqual(sendResponse.Count, getResponse.Count);
            Assert.AreEqual(validTestNumber, getResponse.List[0].Number);
            Assert.AreEqual(sendResponse.List[0].ID, getResponse.List[0].ID);
            Assert.AreEqual(sendResponse.List[0].IDx, getResponse.List[0].IDx);
            Assert.AreEqual(sendResponse.List[0].Points, getResponse.List[0].Points);
            Assert.AreEqual(sendResponse.List[0].Status, getResponse.List[0].Status);

            var deletedResponse =
                mmsFactory
                    .ActionDelete()
                        .Ids(ids)
                        .Execute();

            Assert.AreEqual(sendResponse.Count, deletedResponse.Count);
        }
    }
}
