using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests
{
    [TestClass]
    public class SmsTest : TestBase
    {
        private SMSFactory _factory;

        [TestMethod]
        public void DeletingSentMessage_ExceptionThrown()
        {
            Status sendResponse =
                _factory.ActionSend().SetText("test message").SetTo(_validTestNumber).Execute();

            string[] ids = new string[sendResponse.Count];

            for (int i = 0; i < sendResponse.List.Count; i++)
            {
                ids[i] = sendResponse.List[i].ID;
            }

            Assert.ThrowsException<ActionException>(() => _factory.ActionDelete().Id(ids[0]).Execute());
        }

        [TestMethod]
        public void ScheduledSend_Get_Delete()
        {
            Status sendResponse =
                _factory.ActionSend().
                    SetText("test message").
                    SetTo(_validTestNumber).
                    SetDateSent(DateTime.Now.AddHours(2)).
                    Execute();

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

            Status getResponse =
                _factory.ActionGet().Ids(ids).Execute();

            Assert.AreEqual(sendResponse.Count, getResponse.Count);
            Assert.AreEqual(_validTestNumber, getResponse.List[0].Number);
            Assert.AreEqual(sendResponse.List[0].ID, getResponse.List[0].ID);
            Assert.AreEqual(sendResponse.List[0].IDx, getResponse.List[0].IDx);
            Assert.AreEqual(sendResponse.List[0].Points, getResponse.List[0].Points);
            Assert.AreEqual(sendResponse.List[0].Status, getResponse.List[0].Status);

            Countable deletedResponse =
                _factory.ActionDelete().Id(ids[0]).Execute();

            Assert.AreEqual(sendResponse.Count, deletedResponse.Count);
        }

        [TestMethod]
        public void SendMessageWithParams()
        {
            Status sendResponse =
                _factory.ActionSend().
                    SetText("test [%1%] message [%2%]").
                    SetTo(_validTestNumber).
                    SetParam(0, "par1").
                    SetParam(1, "par2").
                    SetTest().
                    Execute();

            Assert.AreEqual(1, sendResponse.Count);
            Assert.IsTrue(sendResponse.List[0].Points > 0, "Points must be greather then 0");
            Assert.IsNotNull(sendResponse.List[0].ID);
        }

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new SMSFactory(_client, _proxyAddress);
        }
    }
}
