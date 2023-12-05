using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SMSApi.Api;
using SMSApi.Api.Action;

namespace smsapiTests.Unit;

public class SpyProxy : Proxy
{
    public string RequestedUri { get; private set; }

    public Dictionary<string, string> Parameters { get; } = new();

    public void Authentication(IClient client)
    {
        throw new NotImplementedException();
    }

    public HttpResponseEntity Execute(ActionContentType contentType, string uri, NameValueCollection data, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);
        
        return new HttpResponseEntity(new Task<Stream>(() => new MemoryStream()), HttpStatusCode.OK);
    }

    public HttpResponseEntity Execute(ActionContentType contentType, string uri, NameValueCollection data, Stream file, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new HttpResponseEntity(new Task<Stream>(() => new MemoryStream()), HttpStatusCode.OK);
    }

    public HttpResponseEntity Execute(ActionContentType contentType, string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new HttpResponseEntity(Task.FromResult(Stream.Null), HttpStatusCode.OK);
    }

    public Task<HttpResponseEntity> ExecuteAsync(ActionContentType contentType, string uri, NameValueCollection data, RequestMethod method, CancellationToken cancellationToken = default)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new Task<HttpResponseEntity>(() => new HttpResponseEntity(new Task<Stream>(() => new MemoryStream()), HttpStatusCode.OK));
    }

    public Task<HttpResponseEntity> ExecuteAsync(ActionContentType contentType, string uri, NameValueCollection data, Stream file, RequestMethod method, CancellationToken cancellationToken = default)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new Task<HttpResponseEntity>(() => new HttpResponseEntity(new Task<Stream>(() => new MemoryStream()), HttpStatusCode.OK));
    }

    public Task<HttpResponseEntity> ExecuteAsync(ActionContentType contentType, string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method, CancellationToken cancellationToken = default)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new Task<HttpResponseEntity>(null);
    }

    private void SetParameters(NameValueCollection collection)
    {
        Parameters.Clear();

        var map = collection.AllKeys.SelectMany(
            collection.GetValues,
            (k, v) => new KeyValuePair<string, string>(k ,v)
        );

        foreach (var entry in map)
        {
            Parameters.Add(entry.Key, entry.Value);
        }
    }
}
