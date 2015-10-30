using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class EditFieldTest : TestBase
    {
        Field createdField = null;

        [TestMethod]
        public void TestEditField()
        {
            var editedField = contactsFactory.EditField(createdField.Id)
                                .SetName("FieldY")
                                .Execute();
            
            Assert.IsNotNull(editedField.Id);
            Assert.AreEqual(createdField.Id, editedField.Id);
            Assert.AreEqual("FieldY", editedField.Name);
        }

        [TestInitialize]
        public void Initialize()
        {
            var fields = contactsFactory.ListFields().Execute();
            foreach (var field in fields.List) {
                if ("FieldX".Equals(field.Name))
                    createdField = field;
                else if ("FieldY".Equals(field.Name))
                    contactsFactory.DeleteField(field.Id).Execute();
            }

            if (createdField == null)
            {
                createdField = contactsFactory.CreateField()
                                    .SetName("FieldX")
                                    .SetType(Field.TextType)
                                    .Execute();
            }
        }
    }
}
