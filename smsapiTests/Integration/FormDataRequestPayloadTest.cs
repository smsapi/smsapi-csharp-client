using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;

namespace smsapiTests.Integration;

[TestClass]
public class FormDataRequestPayloadTest : IntegrationTestBase
{
    [TestMethod]
    [DataRow(1, "1")]
    [DataRow(true, "True")]
    [DataRow(false, "False")]
    [DataRow(null, "")]
    public void convert_types_to_string(dynamic typeRepresentation, string stringRepresentation)
    {
        var action = GetAction(typeRepresentation);

        action.Execute();

        AssertRequestContainsFormParameter(stringRepresentation);
    }

    private void AssertRequestContainsFormParameter(string value)
    {
        RequestAssert.AssertContainsFormParameter("value", value);
    }

    private AnyFormDataModifyingAction GetAction(dynamic value)
    {
        var action = new AnyFormDataModifyingAction(value);
        action.Proxy(GetProxy());

        return action;
    }

    private class AnyFormDataModifyingAction : Action<Response>
    {
        private dynamic _value;

        public AnyFormDataModifyingAction(dynamic value)
        {
            _value = value;
        }

        protected override RequestMethod Method => RequestMethod.POST;

        protected override ActionContentType ContentType => ActionContentType.FormWww;

        protected override string Uri() => "";

        protected override (NameValueCollection, ISet<KeyValuePair<string, dynamic?>>?) Values()
        {
            return (
                new NameValueCollection(),
                new HashSet<KeyValuePair<string, dynamic?>>
                {
                    KeyValuePair.Create<string, dynamic?>("value", _value)
                }
            );
        }
    }

    private class Response;
}
