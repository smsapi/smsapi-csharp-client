using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class CreateGroupPermissionTest : ContactsTestBase
    {
        private Group _group;
        private GroupPermission _groupPermission;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var groupsResponse = _factory.ListGroups().SetName("example group").Execute();
            if (groupsResponse.Collection.Count > 0)
                _factory.DeleteGroup(groupsResponse.Collection[0].Id).Execute();

            _group = _factory.CreateGroup().SetName("example group").Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _factory.DeleteGroup(_group.Id).Execute();
        }

        [TestMethod]
        public void TestListContactGroups()
        {
            _groupPermission = _factory.CreateGroupPermission(_group.Id)
                                .SetUsername(_subUserName)
                                .SetRead(true)
                                .SetWrite(false)
                                .SetSend(false)
                                .Execute();

            Assert.AreEqual(_subUserName, _groupPermission.Username);
        }
    }
}
