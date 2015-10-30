using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace smsapiTests
{
    [TestClass]
    public class UserTest : TestBase
    {
        [TestMethod]
        public void TestPoints()
        {
            var pointsResponse = userFactory.ActionGetCredits().Execute();
            Assert.IsNotNull(pointsResponse.Points);
            Assert.IsFalse(pointsResponse.isError());
        }

        [TestMethod]
        public void TestAddEditList()
        {
            string usernName = "test_" + DateTime.Now.ToString("his");

            var addResponse =
                userFactory.ActionAdd()
                    .SetUsername(usernName)
                    .SetPassword("7815696ecbf1c96e6894b779456d330e")
                    .Execute();

            Assert.IsFalse(addResponse.isError());
            Assert.AreEqual(client.GetUsername() + "_" + usernName, addResponse.Username);
            Assert.AreEqual("", addResponse.Info);

            var editResponse =
                userFactory.ActionEdit(usernName)
                    .SetInfo("edited info")
                    .Execute();

            Assert.IsFalse(addResponse.isError());
            Assert.AreEqual(addResponse.Username, editResponse.Username);
            Assert.AreEqual("edited info", editResponse.Info);

            var users = userFactory.ActionList().Execute();

            Assert.IsTrue(users.List.Count > 0);
        }
    }
}
