using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class CreateGroupTest : TestBase
    {
        [TestMethod]
        public void TestCreateGroup()
        {
            var group = contactsFactory.CreateGroup().SetName("exampleGroup").Execute();

            Assert.AreEqual("exampleGroup", group.Name);
            Assert.IsNotNull(group.Id);
        }

        [TestInitialize]
        [TestCleanup]
        public void Initialize()
        {
            var groups = contactsFactory.ListGroups().SetName("exampleGroup").Execute();
            foreach (var group in groups.List) {
                contactsFactory.DeleteGroup(group.Id).Execute();
            }
        }
    }
}
