using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsapiTests
{
    [TestClass]
    public class SmsTest : TestBase
    {
        [TestMethod]
        public void TestSendGetDelete()
        {
            var sendResponse =
                smsFactory.ActionSend()
                    .SetText("test message")
                    .SetTo(validTestNumber)
                    .SetDateSent(DateTime.Now.AddHours(2))
                    .Execute();

            Assert.AreEqual(1, sendResponse.Count);
            Assert.IsTrue(sendResponse.List[0].Points > 0, "Points must be greather then 0");
            Assert.IsNotNull(sendResponse.Message);
            Assert.IsNotNull(sendResponse.Parts);

            string[] ids = new string[sendResponse.Count];

            for (int i = 0, l = 0; i < sendResponse.List.Count; i++)
            {
                if (!sendResponse.List[i].isError())
                {
                    //Nie wystąpił błąd podczas wysyłki (numer|treść|parametry... prawidłowe)
                    if (!sendResponse.List[i].isFinal())
                    {
                        //Status nie jest koncowy, może ulec zmianie
                        ids[l] = sendResponse.List[i].ID;
                        l++;
                    }
                }
            }

            var getResponse =
                smsFactory.ActionGet()
                    .Ids(ids)
                    .Execute();

            Assert.AreEqual(sendResponse.Count, getResponse.Count);
            Assert.AreEqual(validTestNumber, getResponse.List[0].Number);
            Assert.AreEqual(sendResponse.List[0].ID, getResponse.List[0].ID);
            Assert.AreEqual(sendResponse.List[0].IDx, getResponse.List[0].IDx);
            Assert.AreEqual(sendResponse.List[0].Points, getResponse.List[0].Points);
            Assert.AreEqual(sendResponse.List[0].Status, getResponse.List[0].Status);
            
            var deletedResponse =
                smsFactory
                    .ActionDelete()
                        .Id(ids[0])
                        .Execute();

            Assert.AreEqual(sendResponse.Count, deletedResponse.Count);
        }

        [TestMethod]
        public void TestSendMessageWithParams()
        {
            var sendResponse =
                smsFactory.ActionSend()
                    .SetText("test [%1%] message [%2%]")
                    .SetTo(validTestNumber)
                    .SetParam(0, "par1")
                    .SetParam(1, "par2")
                    .SetTest(true)
                    .Execute();

            Assert.AreEqual(1, sendResponse.Count);
            Assert.IsTrue(sendResponse.List[0].Points > 0, "Points must be greather then 0");
            Assert.IsNotNull(sendResponse.List[0].ID);
        }
    }
}
