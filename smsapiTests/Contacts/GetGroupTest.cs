using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class EditGroupTest : TestBase
    {
        Group group;

        [TestMethod]
        public void TestGroupGetById()
        {
            var response = contactsFactory.EditGroup(group.Id).SetName("GroupY").Execute();

            Assert.AreEqual(group.Id, response.Id);
            Assert.AreNotEqual(group.Name, response.Name);
            Assert.AreEqual("GroupY", response.Name);
            Assert.AreEqual(group.Idx, response.Idx);
            Assert.AreEqual(group.Description, response.Description);
        }

        [TestInitialize]
        public void Initialize()
        {
            var groups = contactsFactory.ListGroups().SetName("GroupY").Execute();
            if (groups.List.Count > 0)
                contactsFactory.DeleteGroup(groups.List[0].Id).Execute();

            groups = contactsFactory.ListGroups().SetName("exampleGroup").Execute();
            if (groups.List.Count > 0)
                group = groups.List[0];
            else
                group = contactsFactory.CreateGroup().SetName("exampleGroup").Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (group != null) contactsFactory.DeleteGroup(group.Id).Execute();
        }
    }
}
