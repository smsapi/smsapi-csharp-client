using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Response;

namespace smsapiTests
{
    [TestClass]
    public class HlrTest : TestBase
    {
        private HLRFactory _factory;

        [TestMethod]
        public void CheckNumber()
        {
            CheckNumber response = _factory.ActionCheckNumber(_validTestNumber).Execute();

            Assert.AreEqual(1, response.List.Count);
            Assert.IsNotNull(response.List[0].ID);
        }

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();
            _factory = new HLRFactory(_client, _proxyAddress);
        }
    }
}
