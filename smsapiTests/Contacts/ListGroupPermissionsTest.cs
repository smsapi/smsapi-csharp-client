using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListGroupPermissionsTest : TestBase
    {
        Group group;

        [TestMethod]
        public void TestListGroupPermissions()
        {
            var groupPermissions = contactsFactory.ListGroupPermissions(group.Id).Execute();

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

        [TestInitialize]
        public void Initialize()
        {
            var groups = contactsFactory.ListGroups().SetName("exampleGroup").Execute();
            if (groups.List.Count > 0)
            {
                group = groups.List[0];
            } else
            {
                group = contactsFactory.CreateGroup().SetName("exampleGroup").Execute();
            }
        }
    }
}
