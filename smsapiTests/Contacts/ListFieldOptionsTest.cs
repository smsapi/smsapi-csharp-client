using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListFieldOptionsTest : TestBase
    {
        Field field;

        [TestMethod]
        public void TestListFieldOptions()
        {
            var fieldOptions = contactsFactory.ListFieldOptions("city").Execute();

            System.Console.WriteLine("Field options size: " + fieldOptions.Size);
            foreach (var fieldOption in fieldOptions.Collection)
            {
                System.Console.WriteLine("Name: " + fieldOption.Name +
                                         " Value: " + fieldOption.Value);
            }
        }
    }
}
