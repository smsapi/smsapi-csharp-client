using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListFieldsTest : TestBase
    {
        [TestMethod]
        public void TestListFields()
        {
            var fields = contactsFactory.ListFields().Execute();

            foreach (var field in fields.Collection)
            {
                Assert.IsNotNull("", field.Name);
                Assert.AreNotEqual("", field.Name);
                Assert.IsNotNull("", field.Type);
                Assert.AreNotEqual("", field.Type);
            }
        }
    }
}
