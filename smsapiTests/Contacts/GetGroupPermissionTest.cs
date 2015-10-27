using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class GetGroupPermissionTest : TestBase
    {
        Group group;

        [TestMethod]
        public void TestGetGroupPermission()
        {
            var groupPermission = contactsFactory.EditGroupPermission(group.Id, subUserName)
                                .SetRead(true)
                                .SetWrite(true)
                                .SetSend(true)
                                .Execute();

            Assert.IsTrue(groupPermission.Read);
            Assert.IsTrue(groupPermission.Write);
            Assert.IsTrue(groupPermission.Send);
        }

        [TestInitialize]
        public void Initialize()
        {
            var groupsResponse = contactsFactory.ListGroups().SetName("example group").Execute();
            if (groupsResponse.List.Count > 0)
                contactsFactory.DeleteGroup(groupsResponse.List[0].Id).Execute();

            group = contactsFactory.CreateGroup().SetName("example group").Execute();

            contactsFactory.CreateGroupPermission(group.Id)
                                .SetUsername(subUserName)
                                .SetRead(true)
                                .SetWrite(false)
                                .SetSend(false)
                                .Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            contactsFactory.DeleteGroup(group.Id).Execute();
        }
    }
}
