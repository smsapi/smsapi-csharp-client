using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class EditGroupPermissionTest : ContactsTestBase
    {
        private Group group;
        private GroupPermission groupPermission;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var groupsResponse = _factory.ListGroups().SetName("example group").Execute();
            if (groupsResponse.Collection.Count > 0)
                _factory.DeleteGroup(groupsResponse.Collection[0].Id).Execute();

            group = _factory.CreateGroup().SetName("example group").Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _factory.DeleteGroup(group.Id).Execute();
        }

        [TestMethod]
        public void TestListContactGroups()
        {
            groupPermission = _factory.CreateGroupPermission(group.Id)
                                .SetUsername(_username)
                                .SetRead(true)
                                .SetWrite(false)
                                .SetSend(false)
                                .Execute();

            Assert.AreEqual(_username, groupPermission.Username);
        }
    }
}
