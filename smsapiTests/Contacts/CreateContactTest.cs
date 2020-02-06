using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class CreateContactTest : ContactsTestBase
    {
        [TestInitialize]
        [TestCleanup]
        public void Cleanup()
        {
            var contactsResponse = _factory.ListContacts().SetPhoneNumber(_validTestNumber).Execute();
            
            foreach (var contact in contactsResponse.Collection)
            {
                _factory.DeleteContact(contact.Id).Execute();
            }
        }

        [TestMethod]
        public void TestCreateContact()
        {
            var createdContact = _factory.CreateContact()
                    .SetPhoneNumber(_validTestNumber)
                    .Execute();

            Assert.IsNotNull(createdContact);
            Assert.AreEqual(_validTestNumber, createdContact.PhoneNumber);
        }
    }
}
