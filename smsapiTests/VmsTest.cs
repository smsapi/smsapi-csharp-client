using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace smsapiTests
{
    [TestClass]
    public class VmsTest : TestBase
    {
        [TestMethod]
        public void TestSendGetDelete()
        {
            var sendResponse =
                vmsFactory.ActionSend()
                    //.SetFile(file)
                    .SetTTS("test message")
                    .SetTo(validTestNumber)
                    .SetDateSent(DateTime.Now.AddHours(2))
                    .SetTry(3)
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
                vmsFactory.ActionGet()
                    .Ids(ids)
                    .Execute();

            Assert.AreEqual(sendResponse.Count, getResponse.Count);
            Assert.AreEqual(validTestNumber, getResponse.List[0].Number);
            Assert.AreEqual(sendResponse.List[0].ID, getResponse.List[0].ID);
            Assert.AreEqual(sendResponse.List[0].IDx, getResponse.List[0].IDx);
            Assert.AreEqual(sendResponse.List[0].Points, getResponse.List[0].Points);
            Assert.AreEqual(sendResponse.List[0].Status, getResponse.List[0].Status);

            var deletedResponse =
                vmsFactory
                    .ActionDelete()
                        .Ids(ids)
                        .Execute();

            Assert.AreEqual(sendResponse.Count, deletedResponse.Count);
        }
    }
}
