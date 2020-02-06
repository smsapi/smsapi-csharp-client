using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListFieldOptionsTest : ContactsTestBase
    {
        [TestMethod]
        public void TestListFieldOptions()
        {
            var fieldOptions = _factory.ListFieldOptions("city").Execute();

            System.Console.WriteLine("Field options size: " + fieldOptions.Size);
            foreach (var fieldOption in fieldOptions.Collection)
            {
                System.Console.WriteLine("Name: " + fieldOption.Name +
                                         " Value: " + fieldOption.Value);
            }
        }
    }
}
