using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class GetGroupTest : TestBase
    {
        Group group;

        [TestMethod]
        public void TestGroupGetById()
        {
            var response = contactsFactory.GetGroup(group.Id).Execute();

            Assert.AreEqual(group.Id, response.Id);
            Assert.AreEqual(group.Name, response.Name);
            Assert.AreEqual(group.Idx, response.Idx);
            Assert.AreEqual(group.Description, response.Description);
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
