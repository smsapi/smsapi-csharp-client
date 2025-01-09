using System;
using System.Collections.Generic;
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
    
    public RequestMethod RequestMethod { get; private set; } 
    
    public Dictionary<string, dynamic?> Parameters { get; } = new();
    public ICollection<KeyValuePair<string, string>> Files { get; } = new List<KeyValuePair<string, string>>();

    public void Authentication(IClient client)
    {
        throw new NotImplementedException();
    }

    public HttpResponseEntity Execute(ActionContentType contentType, string uri, ISet<KeyValuePair<string, dynamic?>> data, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);
        RequestMethod = method;

        
        return new HttpResponseEntity(new Task<Stream>(() => new MemoryStream()), HttpStatusCode.OK);
    }

    public HttpResponseEntity Execute(ActionContentType contentType, string uri, ISet<KeyValuePair<string, dynamic?>> data, Stream file, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);
        RequestMethod = method;
        Files.Add(KeyValuePair.Create("", new StreamReader(file).ReadToEnd()));
        file.Position = 0;

        return new HttpResponseEntity(new Task<Stream>(() => new MemoryStream()), HttpStatusCode.OK);
    }

    public HttpResponseEntity Execute(ActionContentType contentType, string uri, ISet<KeyValuePair<string, dynamic?>> data, Dictionary<string, Stream> files, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);
        RequestMethod = method;
        foreach (var file in files)
        {
            var content = new StreamReader(file.Value).ReadToEnd();
            file.Value.Position = 0;

            Files.Add(KeyValuePair.Create(file.Key, content));
        }
        
        return new HttpResponseEntity(Task.FromResult(Stream.Null), HttpStatusCode.OK);
    }

    public Task<HttpResponseEntity> ExecuteAsync(ActionContentType contentType, string uri, ISet<KeyValuePair<string, dynamic?>> data, RequestMethod method, CancellationToken cancellationToken = default)
    {
        RequestedUri = uri;
        SetParameters(data);
        RequestMethod = method;

        return new Task<HttpResponseEntity>(() => new HttpResponseEntity(new Task<Stream>(() => new MemoryStream()), HttpStatusCode.OK));
    }

    public Task<HttpResponseEntity> ExecuteAsync(ActionContentType contentType, string uri, ISet<KeyValuePair<string, dynamic?>> data, Stream file, RequestMethod method, CancellationToken cancellationToken = default)
    {
        RequestedUri = uri;
        SetParameters(data);
        RequestMethod = method;

        return new Task<HttpResponseEntity>(() => new HttpResponseEntity(new Task<Stream>(() => new MemoryStream()), HttpStatusCode.OK));
    }

    public Task<HttpResponseEntity> ExecuteAsync(ActionContentType contentType, string uri, ISet<KeyValuePair<string, dynamic?>> data, Dictionary<string, Stream> files, RequestMethod method, CancellationToken cancellationToken = default)
    {
        RequestedUri = uri;
        SetParameters(data);
        RequestMethod = method;

        return new Task<HttpResponseEntity>(null);
    }

    private void SetParameters(ISet<KeyValuePair<string, dynamic?>> collection)
    {
        Parameters.Clear();

        var dictionary = collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        
        foreach (var entry in dictionary)
        {
            Parameters.Add(entry.Key, entry.Value);
        }

        Parameters.Remove("format");//for easier, more concise testing
    }
}
