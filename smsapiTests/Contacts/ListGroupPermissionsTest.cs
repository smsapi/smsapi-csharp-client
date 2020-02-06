using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListGroupPermissionsTest : ContactsTestBase
    {
        private Group _group;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var groups = _factory.ListGroups().SetName("exampleGroup").Execute();
            if (groups.Collection.Count > 0)
            {
                _group = groups.Collection[0];
            }
            else
            {
                _group = _factory.CreateGroup().SetName("exampleGroup").Execute();
            }
        }

        [TestMethod]
        public void TestListGroupPermissions()
        {
            var groupPermissions = _factory.ListGroupPermissions(_group.Id).Execute();

            System.Console.WriteLine("Group permissions size: " + groupPermissions.Size);
            foreach (var groupPermission in groupPermissions.Collection)
            {
                System.Console.WriteLine("GroupId: " + groupPermission.GroupId +
                                         " Username: " + groupPermission.Username +
                                         " Read: " + groupPermission.Read +
                                         " Write: " + groupPermission.Write +
                                         " Send: " + groupPermission.Send);
            }
        }
    }
}
