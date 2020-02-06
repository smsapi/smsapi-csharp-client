using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class GetGroupTest : ContactsTestBase
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
        public void TestGroupGetById()
        {
            var response = _factory.GetGroup(_group.Id).Execute();

            Assert.AreEqual(_group.Id, response.Id);
            Assert.AreEqual(_group.Name, response.Name);
            Assert.AreEqual(_group.Idx, response.Idx);
            Assert.AreEqual(_group.Description, response.Description);
        }
    }
}
