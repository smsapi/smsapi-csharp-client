using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class GroupsTest : ContactsTestBase
    {
        private Group _group;

        [TestCleanup]
        public void Cleanup()
        {
            Groups groups = _factory.ListGroups().Execute();
            foreach (Group group in groups.Collection)
            {
                _factory.DeleteGroup(group.Id).Execute();
            }
        }

        [TestMethod]
        public void CreateGroup()
        {
            Group group = _factory.CreateGroup().SetName("exampleGroup1").Execute();

            Assert.AreEqual("exampleGroup1", group.Name);
            Assert.IsNotNull(group.Id);
        }

        [TestMethod]
        public void CreateGroupPermission()
        {
            GroupPermission groupPermission = _factory.CreateGroupPermission(_group.Id).
                SetUsername(_username).
                SetRead(true).
                SetWrite(false).
                SetSend(false).
                Execute();

            Assert.AreEqual(_username, groupPermission.Username);
        }

        [TestMethod]
        public void EditGroup()
        {
            Group response = _factory.EditGroup(_group.Id).SetName("GroupY").Execute();

            Assert.AreEqual(_group.Id, response.Id);
            Assert.AreNotEqual(_group.Name, response.Name);
            Assert.AreEqual("GroupY", response.Name);
            Assert.AreEqual(_group.Description, response.Description);

            if (string.IsNullOrEmpty(_group.Idx))
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.Idx));
            }
            else
            {
                Assert.AreEqual(_group.Idx, response.Idx);
            }
        }

        [TestMethod]
        public void EditGroupPermission()
        {
            GroupPermission groupPermission = _factory.EditGroupPermission(_group.Id, _username).
                SetRead(true).
                SetWrite(true).
                SetSend(true).
                Execute();

            Assert.IsTrue(groupPermission.Read);
            Assert.IsTrue(groupPermission.Write);
            Assert.IsTrue(groupPermission.Send);
        }

        [TestMethod]
        public void GetGroup()
        {
            Group response = _factory.GetGroup(_group.Id).Execute();

            Assert.AreEqual(_group.Id, response.Id);
            Assert.AreEqual(_group.Name, response.Name);
            Assert.AreEqual(_group.Description, response.Description);

            if (string.IsNullOrEmpty(_group.Idx))
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.Idx));
            }
            else
            {
                Assert.AreEqual(_group.Idx, response.Idx);
            }
        }

        [TestMethod]
        public void ListGroupPermissions()
        {
            _factory.ListGroupPermissions(_group.Id).Execute();
        }

        [TestMethod]
        public void ListGroups()
        {
            _factory.ListGroups().Execute();
        }

        [TestMethod]
        public void ListGroupsWithFilterByName()
        {
            Groups listResponse = _factory.ListGroups().SetName("exampleGroup").Execute();

            Assert.AreEqual(1, listResponse.Collection.Count);
        }

        [TestMethod]
        public void ListWithFilterByName_ShouldNotFound()
        {
            Groups listResponse = _factory.ListGroups().SetName("missingGroup").Execute();

            Assert.AreEqual(0, listResponse.Collection.Count);
        }

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();

            _group = _factory.CreateGroup().SetName("exampleGroup").Execute();
        }
    }
}
