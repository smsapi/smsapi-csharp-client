using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class GetGroupPermissionTest : ContactsTestBase
    {
        private Group _group;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var groupsResponse = _factory.ListGroups().SetName("example group").Execute();
            if (groupsResponse.Collection.Count > 0)
                _factory.DeleteGroup(groupsResponse.Collection[0].Id).Execute();

            _group = _factory.CreateGroup().SetName("example group").Execute();

            _factory.CreateGroupPermission(_group.Id)
                                .SetUsername(_subUserName)
                                .SetRead(true)
                                .SetWrite(false)
                                .SetSend(false)
                                .Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _factory.DeleteGroup(_group.Id).Execute();
        }

        [TestMethod]
        public void TestGetGroupPermission()
        {
            var groupPermission = _factory.EditGroupPermission(_group.Id, _subUserName)
                                .SetRead(true)
                                .SetWrite(true)
                                .SetSend(true)
                                .Execute();

            Assert.IsTrue(groupPermission.Read);
            Assert.IsTrue(groupPermission.Write);
            Assert.IsTrue(groupPermission.Send);
        }
    }
}
