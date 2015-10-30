using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class CreateContactTest : TestBase
    {
        [TestMethod]
        public void TestCreateContact()
        {
            var createdContact = contactsFactory.CreateContact()
                    .SetPhoneNumber(validTestNumber)
                    .Execute();

            Assert.IsNotNull(createdContact);
            Assert.AreEqual(validTestNumber, createdContact.PhoneNumber);
        }

        [TestInitialize]
        [TestCleanup]
        public void Clean()
        {
            var contactsResponse = contactsFactory.ListContacts().SetPhoneNumber(validTestNumber).Execute();
            
            foreach (var contact in contactsResponse.List)
            {
                contactsFactory.DeleteContact(contact.Id).Execute();
            }
        }
    }
}
