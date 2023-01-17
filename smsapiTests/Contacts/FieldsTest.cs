using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class FieldsTest : ContactsTestBase
    {
        private Field _field;

        [TestCleanup]
        public void Cleanup()
        {
            Fields fields = _factory.ListFields().Execute();
            foreach (Field field in fields.Collection)
            {
                _factory.DeleteField(field.Id).Execute();
            }
        }

        [TestMethod]
        public void CreateField()
        {
            _field = _factory.CreateField().SetName("FieldXX").SetType(Field.TextType).Execute();

            Assert.IsNotNull(_field.Id);
            Assert.AreEqual("FieldXX", _field.Name);
        }

        [TestMethod]
        public void EditField()
        {
            Field editedField = _factory.EditField(_field.Id).SetName("FieldY").Execute();

            Assert.IsNotNull(editedField.Id);
            Assert.AreEqual(_field.Id, editedField.Id);
            Assert.AreEqual("FieldY", editedField.Name);
        }

        [TestMethod]
        public void ListFieldOptions()
        {
            _factory.ListFieldOptions("city").Execute();
        }

        [TestMethod]
        public void ListFields()
        {
            Fields fields = _factory.ListFields().Execute();

            foreach (Field field in fields.Collection)
            {
                Assert.IsNotNull("", field.Name);
                Assert.AreNotEqual("", field.Name);
                Assert.IsNotNull("", field.Type);
                Assert.AreNotEqual("", field.Type);
            }
        }

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _field = _factory.CreateField().SetName("FieldX").SetType(Field.TextType).Execute();
        }
    }
}
