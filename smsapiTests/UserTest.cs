using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using System;

namespace smsapiTests
{
    [TestClass]
    public class UserTest : TestBase
    {
        private UserFactory _factory;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new UserFactory(_client);
        }

        [TestMethod]
        public void TestPoints()
        {
            var pointsResponse = _factory.ActionGetCredits().Execute();
            Assert.IsNotNull(pointsResponse.Points);
            Assert.IsFalse(pointsResponse.isError());
        }

        [TestMethod]
        public void TestAddEditList()
        {
            string usernName = "test_" + DateTime.Now.ToString("his");

            var addResponse =
                _factory.ActionAdd()
                    .SetUsername(_subUserName)
                    .SetPassword("7815696ecbf1c96e6894b779456d330e")
                    .Execute();

            Assert.IsFalse(addResponse.isError());
            Assert.AreEqual("", addResponse.Info);

            var editResponse =
                _factory.ActionEdit(_subUserName)
                    .SetInfo("edited info")
                    .Execute();

            Assert.IsFalse(addResponse.isError());
            Assert.AreEqual(addResponse.Username, editResponse.Username);
            Assert.AreEqual("edited info", editResponse.Info);

            var users = _factory.ActionList().Execute();

            Assert.IsTrue(users.List.Count > 0);
        }
    }
}
