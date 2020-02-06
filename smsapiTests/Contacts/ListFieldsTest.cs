using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class ListFieldsTest : ContactsTestBase
    {
        [TestMethod]
        public void TestListFields()
        {
            var fields = _factory.ListFields().Execute();

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
