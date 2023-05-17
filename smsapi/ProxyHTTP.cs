using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace SMSApi.Api
{
    public class ProxyHTTP : Proxy
    {
        private readonly string baseUrl;
        private IClient authentication;

        public ProxyHTTP(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public void Authentication(IClient client)
        {
            authentication = client;
        }

        public Stream Execute(string uri, NameValueCollection data, RequestMethod method)
        {
            return Execute(uri, data, new Dictionary<string, Stream>(), method);
        }

        public Stream Execute(
            string uri,
            NameValueCollection data,
            Stream file,
            RequestMethod method)
        {
            return Execute(uri, data, new Dictionary<string, Stream> { { "file", file } }, method);
        }

        public Stream Execute(
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method)
        {
            var responseStream = new MemoryStream();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            RestClient client = CreateClient();
            RestRequest request = CreateRequest(uri, responseStream, data, files, method);

            try
            {
                client.Execute(request);
            }
            catch (System.Exception e)
            {
                throw new ProxyException("Failed to get response from " + uri, e);
            }

            return responseStream;
        }

        public async Task<Stream> ExecuteAsync(
            string uri,
            NameValueCollection data,
            RequestMethod method)
        {
            return await ExecuteAsync(uri, data, new Dictionary<string, Stream>(), method);
        }

        public async Task<Stream> ExecuteAsync(
            string uri,
            NameValueCollection data,
            Stream file,
            RequestMethod method)
        {
            return await ExecuteAsync(uri, data, new Dictionary<string, Stream> { { "file", file } }, method);
        }

        public async Task<Stream> ExecuteAsync(
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method)
        {
            var responseStream = new MemoryStream();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            RestClient client = CreateClient();
            RestRequest request = CreateRequest(uri, responseStream, data, files, method);

            try
            {
                await client.ExecuteAsync(request);
            }
            catch (System.Exception e)
            {
                throw new ProxyException("Failed to get response from " + uri, e);
            }

            return responseStream;
        }

        private static RestRequest CreateRequest(
            string uri,
            Stream responseStream,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method)
        {
            var request = new RestRequest(uri)
            {
                Method = method.ToMethod(),
                ResponseWriter = s =>
                {
                    s.CopyTo(responseStream);
                    return s;
                }
            };

            foreach (string key in data.Keys)
            {
                request.AddParameter(key, data[key]);
            }

            foreach (KeyValuePair<string, Stream> file in files)
            {
                request.AddFile(file.Key, () => file.Value, file.Key);
            }

            return request;
        }

        private RestClient CreateClient()
        {
            var options = new RestClientOptions(baseUrl);

            if (authentication != null)
            {
                options.UserAgent = authentication.GetClientAgent();
                options.Authenticator = authentication.Authenticator;
            }

            return new RestClient(options);
        }
    }
}
