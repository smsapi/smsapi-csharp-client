using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class CreateGroupPermissionTest : TestBase
    {
        Group group;
        GroupPermission groupPermission;

        [TestMethod]
        public void TestListContactGroups()
        {
            groupPermission = contactsFactory.CreateGroupPermission(group.Id)
                                .SetUsername(subUserName)
                                .SetRead(true)
                                .SetWrite(false)
                                .SetSend(false)
                                .Execute();

            Assert.AreEqual(subUserName, groupPermission.Username);
        }

        [TestInitialize]
        public void Initialize()
        {
            var groupsResponse = contactsFactory.ListGroups().SetName("example group").Execute();
            if (groupsResponse.List.Count > 0)
                contactsFactory.DeleteGroup(groupsResponse.List[0].Id).Execute();

            group = contactsFactory.CreateGroup().SetName("example group").Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //contactsFactory.DeleteGroupPermission(subUserName, group.Id).Execute();
            contactsFactory.DeleteGroup(group.Id).Execute();
        }
    }
}
