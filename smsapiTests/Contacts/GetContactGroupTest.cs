using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class GetContactGroupTest : ContactsTestBase
    {
        private Contact _contact;
        private Group _group;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var contactsResponse = _factory.ListContacts().SetPhoneNumber(_validTestNumber).Execute();
            if (contactsResponse.Collection.Count > 0)
                _contact = contactsResponse.Collection[0];
            else
                _contact = _factory.CreateContact().SetPhoneNumber(_validTestNumber).Execute();

            var groupsResponse = _factory.ListGroups().SetName("example group").Execute();
            if (groupsResponse.Collection.Count > 0)
                _group = groupsResponse.Collection[0];
            else
                _group = _factory.CreateGroup().SetName("example group").Execute();

            _factory.BindContactToGroup(_contact.Id, _group.Id).Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _factory.DeleteContact(_contact.Id).Execute();
            _factory.DeleteGroup(_group.Id).Execute();
        }

        [TestMethod]
        public void TestGetContactGroup()
        {
            var groupResponse = _factory.GetContactGroup(_contact.Id, _group.Id).Execute();

            Assert.AreEqual(_group.Id, groupResponse.Id);
        }
    }
}
