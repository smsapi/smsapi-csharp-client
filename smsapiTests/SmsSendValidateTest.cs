using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api.Action;

namespace smsapiTests
{
    [TestClass]
    public class SmsSendValidateTest
    {
        [TestMethod]
        public void Validate_TextAndTemplateBothNull_Throws()
        {
            var send = new SMSSend().SetTo("48000000000");

            var ex = Assert.ThrowsException<TargetInvocationException>(() => InvokeValidate(send));
            Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentException));
            Assert.AreEqual("Cannot send message without text!", ex.InnerException.Message);
        }

        [TestMethod]
        public void Validate_TextSet_DoesNotThrow()
        {
            var send = new SMSSend().SetTo("48000000000").SetText("hello");

            InvokeValidate(send);
        }

        [TestMethod]
        public void Validate_TemplateSet_DoesNotThrow()
        {
            var send = new SMSSend().SetTo("48000000000").SetTemplate("welcome");

            InvokeValidate(send);
        }

        [TestMethod]
        public void Validate_ToAndGroupBothSet_Throws()
        {
            var send = new SMSSend().SetTo("48000000000").SetGroup("g").SetText("hi");

            var ex = Assert.ThrowsException<TargetInvocationException>(() => InvokeValidate(send));
            Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentException));
            Assert.AreEqual("Cannot use 'to' and 'group' at the same time!", ex.InnerException.Message);
        }

        private static void InvokeValidate(SMSSend send)
        {
            var method = typeof(SMSSend).GetMethod("Validate", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(send, Array.Empty<object>());
        }
    }
}
