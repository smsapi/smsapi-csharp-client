using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;
using SMSApi.Api.Response;
using SMSApi.Api.Response.ResponseResolver;
using smsapiTests.Unit.Fixture;
using smsapiTests.Unit.Helper;

namespace smsapiTests.Unit.Action;

[TestClass]
public class CollectionIteratorTest
{
    private readonly ProxyStub _proxy = new();

    [TestMethod]
    public void iterate_through_single_result()
    {
        var mockedResult = CollectionMother.WithItems(
            new Dictionary<string, object> { { "i", 0 } },
            new Dictionary<string, object> { { "i", 1 } }
        );
        _proxy.SyncExecutionResponse = new HttpResponseEntity(
            mockedResult.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetAction().ToIterator(10);

        var i = 0;
        foreach (var iterableResult in result)
            Assert.AreEqual(i++, iterableResult.I);

        Assert.AreEqual(2, i);
    }

    [TestMethod]
    public void iterate_through_pages()
    {
        var mockedResult = CollectionMother.WithItems(
            new Dictionary<string, object> { { "i", 0 } },
            new Dictionary<string, object> { { "i", 1 } },
            new Dictionary<string, object> { { "i", 2 } },
            new Dictionary<string, object> { { "i", 3 } }
        );
        _proxy.SyncExecutionResponse = new HttpResponseEntity(
            mockedResult.ToHttpEntityStreamTask(),
            HttpStatusCode.OK
        );

        var result = GetAction().ToIterator(1);

        var i = 0;
        foreach (var iterableResult in result)
            Assert.AreEqual(i++, iterableResult.I);

        Assert.AreEqual(4, i);
    }

    private IterableAction GetAction()
    {
        var action = new IterableAction();
        action.Proxy(_proxy);

        return action;
    }

    private class IterableAction : Action<BasicCollection<IterableResult>>, IPaginable
    {
        protected override RequestMethod Method => RequestMethod.GET;

        public uint? Limit { get; set; }
        public uint? Offset { get; set; }

        protected override string Uri() => "";
    }

    private class IterableResult : IResponseCodeAwareResolver
    {
        public int I;
    }
}
