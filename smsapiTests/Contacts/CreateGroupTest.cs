using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class CreateGroupTest : ContactsTestBase
    {
        [TestInitialize]
        [TestCleanup]
        public void Cleanup()
        {
            var groups = _factory.ListGroups().SetId("0").Execute();
            foreach (var group in groups.Collection)
            {
                _factory.DeleteGroup(group.Id).Execute();
            }
        }

        [TestMethod]
        public void TestCreateGroup()
        {
            var group = _factory.CreateGroup().SetIdx("testGroup").SetName("exampleGroup").Execute();

            Assert.AreEqual("exampleGroup", group.Name);
            Assert.IsNotNull(group.Id);
        }
    }
}
