using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSApi.Api;
using SMSApi.Api.Action;

namespace smsapiTests.Unit.Action;

[TestClass]
public class ActionPaginationTest
{
    private string Path = "blacklist/phone_numbers";
    
    private readonly SpyProxy _spyProxy = new();
    
    [TestMethod]
    public void raw_uri()
    {
        var action = GetAction();

        action.Execute();
        
        Assert.AreEqual("blacklist/phone_numbers", _spyProxy.RequestedUri);
    }
    
    [TestMethod]
    public void add_limit_to_uri()
    {
        var limit = 10;
        var action = GetAction();
        action.Limit = limit;

        action.Execute();
        
        Assert.AreEqual("blacklist/phone_numbers?limit=10", _spyProxy.RequestedUri);
    }
    
    [TestMethod]
    public void add_offset_to_uri()
    {
        var offset = 10;
        var action = GetAction();
        action.Offset = offset;

        action.Execute();
        
        Assert.AreEqual("blacklist/phone_numbers?offset=10", _spyProxy.RequestedUri);
    }
    
    [TestMethod]
    public void add_limit_and_offset_to_uri()
    {
        var limit = 5;
        var offset = 10;
        var action = GetAction();
        action.Limit = limit;
        action.Offset = offset;

        action.Execute();
        
        Assert.AreEqual("blacklist/phone_numbers?limit=5&offset=10", _spyProxy.RequestedUri);
    }

    private PaginableAction GetAction()
    {
        var action = new PaginableAction(Path);
        action.Proxy(_spyProxy);

        return action;
    }

    private class PaginableAction : Action<Response>, IPaginable
    {
        private readonly string Path;

        public PaginableAction(string path)
        {
            Path = path;
        }
        
        protected override RequestMethod Method => RequestMethod.GET;

        protected override string Uri() => Path;
        
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }

    private class Response{}
}
