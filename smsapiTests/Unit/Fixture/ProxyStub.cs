using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using SMSApi.Api;

namespace smsapiTests.Unit.Fixture;

public class ProxyStub : Proxy
{
    public HttpResponseEntity SyncExecutionResponse;
    
    public void Authentication(IClient client)
    {
        throw new System.NotImplementedException();
    }

    public HttpResponseEntity Execute(string uri, NameValueCollection data, RequestMethod method)
    {
        throw new System.NotImplementedException();
    }

    public HttpResponseEntity Execute(string uri, NameValueCollection data, Stream file, RequestMethod method)
    {
        throw new System.NotImplementedException();
    }

    public HttpResponseEntity Execute(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method)
    {
        return SyncExecutionResponse;
    }

    public Task<HttpResponseEntity> ExecuteAsync(string uri, NameValueCollection data, RequestMethod method)
    {
        throw new System.NotImplementedException();
    }

    public Task<HttpResponseEntity> ExecuteAsync(string uri, NameValueCollection data, Stream file, RequestMethod method)
    {
        throw new System.NotImplementedException();
    }

    public Task<HttpResponseEntity> ExecuteAsync(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method)
    {
        throw new System.NotImplementedException();
    }
}
