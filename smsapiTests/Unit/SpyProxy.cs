using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SMSApi.Api;

namespace smsapiTests.Unit;

public class SpyProxy : Proxy
{
    public string RequestedUri { get; private set; }

    public Dictionary<string, string> Parameters { get; } = new();

    public void Authentication(IClient client)
    {
        throw new System.NotImplementedException();
    }

    public Stream Execute(string uri, NameValueCollection data, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new MemoryStream();
    }

    public Stream Execute(string uri, NameValueCollection data, Stream file, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new MemoryStream();
    }

    public Stream Execute(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new MemoryStream();
    }

    public Task<Stream> ExecuteAsync(string uri, NameValueCollection data, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new Task<Stream>(null);
    }

    public Task<Stream> ExecuteAsync(string uri, NameValueCollection data, Stream file, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new Task<Stream>(null);
    }

    public Task<Stream> ExecuteAsync(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method)
    {
        RequestedUri = uri;
        SetParameters(data);

        return new Task<Stream>(null);
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
