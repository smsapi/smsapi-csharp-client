using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class EditFieldTest : ContactsTestBase
    {
        Field createdField = null;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var fields = _factory.ListFields().Execute();
            foreach (var field in fields.Collection) {
                if ("FieldX".Equals(field.Name))
                    createdField = field;
                else if ("FieldY".Equals(field.Name))
                    _factory.DeleteField(field.Id).Execute();
            }

            if (createdField == null)
            {
                createdField = _factory.CreateField()
                                    .SetName("FieldX")
                                    .SetType(Field.TextType)
                                    .Execute();
            }
        }

        [TestMethod]
        public void TestEditField()
        {
            var editedField = _factory.EditField(createdField.Id)
                                .SetName("FieldY")
                                .Execute();

            Assert.IsNotNull(editedField.Id);
            Assert.AreEqual(createdField.Id, editedField.Id);
            Assert.AreEqual("FieldY", editedField.Name);
        }
    }
}
