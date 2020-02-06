using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListGroupsTest : ContactsTestBase
    {
        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var response = _factory.ListGroups().SetName("example group 1").Execute();
            if (response.Collection.Count == 0)
            {
                _factory.CreateGroup().SetName("example group 1").Execute();
            }

            response = _factory.ListGroups().SetName("example group 2").Execute();
            if (response.Collection.Count == 0)
            {
                _factory.CreateGroup().SetName("example group 2").Execute();
            }

            response = _factory.ListGroups().SetName("example group not found").Execute();
            if (response.Collection.Count > 0)
            {
                _factory.DeleteGroup(response.Collection[0].Id).Execute();
            }
        }

        [TestMethod]
        public void TestList()
        {
            var groups = _factory.ListGroups()
                                .Execute();

            System.Console.WriteLine("Groups size: " + groups.Size);
            foreach (var group in groups.Collection)
            {
                System.Console.WriteLine("Id: " + group.Id +
                                         " Name: " + group.Name +
                                         " ContactsCount: " + group.ContactsCount +
                                         " DateCreated: " + group.DateCreated +
                                         " DateUpdated: " + group.DateUpdated +
                                         " Description: " + group.Description +
                                         " CreatedBy: " + group.CreatedBy +
                                         " Idx: " + group.Idx);
                foreach (var groupPermission in group.Permissions)
                {
                    System.Console.WriteLine("GroupId: " + groupPermission.GroupId +
                                             " Username: " + groupPermission.Username +
                                             " Write: " + groupPermission.Write +
                                             " Read: " + groupPermission.Read +
                                             " Send: " + groupPermission.Send);
                }
            }
        }

        [TestMethod]
        public void TestListWithFilterByName()
        {
            var listResponse = _factory.ListGroups().SetName("example group 1").Execute();

            Assert.AreEqual(1, listResponse.Collection.Count);
        }

        [TestMethod]
        public void TestShouldNotFound_ListWithFilterByName()
        {
            var listResponse = _factory.ListGroups().SetName("example group not found").Execute();

            Assert.AreEqual(0, listResponse.Collection.Count);
        }
    }
}
