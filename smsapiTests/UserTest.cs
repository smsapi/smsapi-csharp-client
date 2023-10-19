using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests
{
    [TestClass]
    public class UserTest : TestBase
    {
        private UserFactory _factory;

        [TestMethod]
        public void Add_Edit_List()
        {
            string usernName = "test_" + DateTime.Now.ToString("his");

            User addResponse =
                _factory.ActionAdd().SetUsername(usernName).SetPassword("7815696ecbf1c96e6894b779456d330e").Execute();

            Assert.IsFalse(addResponse.IsError());
            Assert.AreEqual("", addResponse.Info);

            User editResponse =
                _factory.ActionEdit(usernName).SetInfo("edited info").Execute();

            Assert.IsFalse(addResponse.IsError());
            Assert.AreEqual(addResponse.Username, editResponse.Username);
            Assert.AreEqual("edited info", editResponse.Info);

            Array<User> users = _factory.ActionList().Execute();

            Assert.IsTrue(users.List.Count > 0);
        }

        [TestMethod]
        public void GetCredits()
        {
            Credits pointsResponse = _factory.ActionGetCredits().Execute();
            Assert.IsNotNull(pointsResponse.Points);
            Assert.IsFalse(pointsResponse.IsError());
        }

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new UserFactory(_client);
        }
    }
}
