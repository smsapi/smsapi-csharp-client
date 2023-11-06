using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;
using SMSApi.Api.Response.ResponseResolver;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ContactsTest : ContactsTestBase
    {
        private Contact _contact;
        private Group _group;

        [TestMethod]
        public void BindContactToGroup()
        {
            ErrorAwareResponse response = _factory.BindContactToGroup(_contact.Id, _group.Id).Execute();
            Assert.IsFalse(response.IsError());

            _factory.DeleteGroup(_group.Id).Execute();
        }

        [TestCleanup]
        public void Cleanup()
        {
            SMSApi.Api.Response.Contacts contactsResponse =
                _factory.ListContacts().SetPhoneNumber(_validTestNumber).Execute();
            foreach (Contact contact in contactsResponse.Collection)
            {
                _factory.DeleteContact(contact.Id).Execute();
            }

            Groups groups = _factory.ListGroups().Execute();
            foreach (Group group in groups.Collection)
            {
                _factory.DeleteGroup(group.Id).Execute();
            }
        }

        [TestMethod]
        public void CreateContact()
        {
            Cleanup();

            Contact createdContact = _factory.CreateContact().SetPhoneNumber(_validTestNumber).Execute();

            Assert.IsNotNull(createdContact);
            Assert.AreEqual(_validTestNumber, createdContact.PhoneNumber);
        }

        [TestMethod]
        public void EditContact()
        {
            Contact editContact = _factory.EditContact(_contact.Id).SetFirstName("Tester").Execute();

            Assert.AreEqual(_contact.Id, editContact.Id);
            Assert.AreEqual("Tester", editContact.FirstName);
        }

        [TestMethod]
        public void GetContact()
        {
            Contact getResponse = _factory.GetContact(_contact.Id).Execute();

            Assert.AreEqual(_contact.PhoneNumber, getResponse.PhoneNumber);
        }

        [TestMethod]
        public void GetContactGroup()
        {
            _factory.BindContactToGroup(_contact.Id, _group.Id).Execute();

            Group groupResponse = _factory.GetContactGroup(_contact.Id, _group.Id).Execute();

            Assert.AreEqual(_group.Id, groupResponse.Id);
        }

        [TestMethod]
        public void ListContactGroups()
        {
            _factory.BindContactToGroup(_contact.Id, _group.Id).Execute();

            Groups groupsResponse = _factory.ListContactGroups(_contact.Id).Execute();

            Assert.AreEqual(1, groupsResponse.Collection.Count);
            Assert.AreEqual(_group.Id, groupsResponse.Collection[0].Id);
        }

        [TestMethod]
        public void ListContacts()
        {
            _factory.ListContacts().Execute();
        }

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();

            SMSApi.Api.Response.Contacts contactsResponse =
                _factory.ListContacts().SetPhoneNumber(_validTestNumber).Execute();
            if (contactsResponse.Collection.Count > 0)
            {
                _contact = contactsResponse.Collection[0];
            }
            else
            {
                _contact = _factory.CreateContact().SetPhoneNumber(_validTestNumber).Execute();
            }

            Groups groupsResponse = _factory.ListGroups().SetName("exampleGroup").Execute();
            if (groupsResponse.Collection.Count > 0)
            {
                _group = groupsResponse.Collection[0];
            }
            else
            {
                _group = _factory.CreateGroup().SetName("exampleGroup").Execute();
            }
        }
    }
}
