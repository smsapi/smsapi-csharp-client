using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class CreateFieldTest : TestBase
    {
        Field createdField;

        [TestMethod]
        public void TestCreateField()
        {
            createdField = contactsFactory.CreateField()
                                .SetName("FieldX")
                                .SetType(Field.TextType)
                                .Execute();

            Assert.IsNotNull(createdField.Id);
            Assert.AreEqual("FieldX", createdField.Name);
        }

        [TestInitialize]
        public void Initialize()
        {
            var fields = contactsFactory.ListFields().Execute();
            foreach (var field in fields.List)
            {
                if ("FieldX".Equals(field.Name))
                    contactsFactory.DeleteField(field.Id).Execute();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (createdField != null)
            {
                contactsFactory.DeleteField(createdField.Id).Execute();
            }
        }
    }
}
