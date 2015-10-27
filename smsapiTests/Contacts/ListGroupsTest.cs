using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListGroupsTest : TestBase
    {
        [TestMethod]
        public void TestList()
        {
            var groups = contactsFactory.ListGroups()
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
            var listResponse = contactsFactory.ListGroups().SetName("example group 1").Execute();

            Assert.AreEqual(1, listResponse.List.Count);
        }

        [TestMethod]
        public void TestShouldNotFound_ListWithFilterByName()
        {
            var listResponse = contactsFactory.ListGroups().SetName("example group not found").Execute();

            Assert.AreEqual(0, listResponse.List.Count);
        }

        [TestInitialize]
        public void Initialize()
        {
            var response = contactsFactory.ListGroups().SetName("example group 1").Execute();
            if (response.List.Count == 0)
            {
                contactsFactory.CreateGroup().SetName("example group 1").Execute();
            }

            response = contactsFactory.ListGroups().SetName("example group 2").Execute();
            if (response.List.Count == 0)
            {
                contactsFactory.CreateGroup().SetName("example group 2").Execute();
            }

            response = contactsFactory.ListGroups().SetName("example group not found").Execute();
            if (response.List.Count > 0)
            {
                contactsFactory.DeleteGroup(response.List[0].Id).Execute();
            }
        }
    }
}
