using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests.Contacts
{
    [TestClass]
    public class CreateFieldTest : ContactsTestBase
    {
        private Field _createdField;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            var fields = _factory.ListFields().Execute();
            foreach (var field in fields.Collection)
            {
                if ("FieldX".Equals(field.Name))
                    _factory.DeleteField(field.Id).Execute();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_createdField != null)
            {
                _factory.DeleteField(_createdField.Id).Execute();
            }
        }

        [TestMethod]
        public void TestCreateField()
        {
            _createdField = _factory.CreateField()
                                .SetName("FieldX")
                                .SetType(Field.TextType)
                                .Execute();

            Assert.IsNotNull(_createdField.Id);
            Assert.AreEqual("FieldX", _createdField.Name);
        }
    }
}
