using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace smsapiTests
{
    [TestClass]
    public class PhonebookTest : TestBase
    {
        [TestMethod]
        public void TestGroup_AddEditGetListDelete()
        {
            string groupName = "new group123" + DateTime.Now.ToString("his");

            phonebookFactory.ActionGroupAdd()
                .SetInfo("ooo info")
                .SetName(groupName)
                .Execute();

            var group =
                phonebookFactory.ActionGroupEdit(groupName)
                    .SetName(groupName + "#edit")
                    .SetInfo("edited info")
                    .Execute();

            group =
                phonebookFactory.ActionGroupGet(group.Name)
                    .Execute();

            var groups = phonebookFactory.ActionGroupList().Execute();

            foreach (var g in groups.List)
            {
                Assert.IsNotNull(g.Name);
                Assert.IsNotNull(g.NumbersCount);
                Assert.IsNotNull(g.Info);
            }

            phonebookFactory.ActionGroupDelete(group.Name)
                .Contacts(false)
                .Execute();
        }

        [TestMethod]
        public void TestContact_AddEditListGetDelete()
        {
            var contact =
                phonebookFactory.ActionContactAdd(validTestNumber)
                    .SetFirstName("Test contact" + DateTime.Now.ToString("his"))
                    .Execute();

            contact =
                phonebookFactory.ActionContactEdit(contact.Number)
                    .SetFirstName("Test contact" + DateTime.Now.ToString("his") + "#edited")
                    .SetNumber(validTestNumber)
                    .Execute();

            var contacts = phonebookFactory.ActionContactList().Execute();
            foreach (var c in contacts.List)
            {
                System.Console.WriteLine(c.Number + " " + c.FirstName + " " + c.LastName + " " + c.Gender);
            }

            contact = phonebookFactory.ActionContactGet(contact.Number).Execute();

            phonebookFactory.ActionContactDelete(contact.Number).Execute();
        }
    }
}
