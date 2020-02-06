using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListContactsTest : ContactsTestBase
    {
        [TestMethod]
        public void TestListContacts()
        {
            var contacts = _factory.ListContacts()
                                .Execute();

            System.Console.WriteLine("Contacts size: " + contacts.Size);
            foreach (var contact in contacts.Collection)
            {
                System.Console.WriteLine("Id: " + contact.Id +
                                         " Idx: " + contact.Idx +
                                         " FirstName: " + contact.FirstName +
                                         " LastName: " + contact.LastName +
                                         " BirthdayDate: " + contact.BirthdayDate +
                                         " PhoneNumber: " + contact.PhoneNumber +
                                         " Email: " + contact.Email +
                                         " Gender: " + contact.Gender +
                                         " City: " + contact.City +
                                         " Source: " + contact.Source +
                                         " DateCreated: " + contact.DateCreated +
                                         " DateUpdated: " + contact.DateUpdated +
                                         " Description: " + contact.Description);
            }
        }
    }
}
