using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class EditGroupTest : ContactsTestBase
    {
        private Group _group;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var groups = _factory.ListGroups().SetName("GroupY").Execute();
            if (groups.Collection.Count > 0)
                _factory.DeleteGroup(groups.Collection[0].Id).Execute();

            groups = _factory.ListGroups().SetName("exampleGroup").Execute();
            if (groups.Collection.Count > 0)
                _group = groups.Collection[0];
            else
                _group = _factory.CreateGroup().SetName("exampleGroup").Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_group != null) _factory.DeleteGroup(_group.Id).Execute();
        }

        [TestMethod]
        public void TestGroupGetById()
        {
            var response = _factory.EditGroup(_group.Id).SetName("GroupY").Execute();

            Assert.AreEqual(_group.Id, response.Id);
            Assert.AreNotEqual(_group.Name, response.Name);
            Assert.AreEqual("GroupY", response.Name);
            Assert.AreEqual(_group.Idx, response.Idx);
            Assert.AreEqual(_group.Description, response.Description);
        }
    }
}
