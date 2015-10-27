using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListContactsTest : TestBase
    {
        [TestMethod]
        public void TestListContacts()
        {
            var contacts = contactsFactory.ListContacts()
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
