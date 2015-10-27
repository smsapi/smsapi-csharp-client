using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class GetContactTest : TestBase
    {
        private Contact contact;

        [TestMethod]
        public void TestGetContact()
        {
            var getResponse = contactsFactory.GetContact(contact.Id).Execute();

            Assert.AreEqual(contact.PhoneNumber, getResponse.PhoneNumber);
        }

        [TestInitialize]
        [TestCleanup]
        public void Initialize()
        {
            var contactsResponse = contactsFactory.ListContacts().SetPhoneNumber(validTestNumber).Execute();
            if (contactsResponse.List.Count > 0)
            {
                contact = contactsResponse.List[0];
            } else
            {
                contact = contactsFactory.CreateContact().SetPhoneNumber(validTestNumber).Execute();
            }
        }
    }
}
