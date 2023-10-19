using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpClient client = CreateClient();

            try
            {
                return client.SendRequest(method, uri, data, files).GetAwaiter().GetResult();
            }
            catch (System.Exception e)
            {
                throw new ProxyException("Failed to get response from " + uri, e);
            }
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
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpClient client = CreateClient();

            try
            {
                return await client.SendRequest(method, uri, data, files);
            }
            catch (System.Exception e)
            {
                throw new ProxyException("Failed to get response from " + uri, e);
            }
        }
        
        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            if (authentication == null) return client;
            
            var authHeader = authentication.DefaultRequestHeaders;

            client.DefaultRequestHeaders.Add(authHeader.Key, authHeader.Value);
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", authentication.GetClientAgent());

            return client;
        }
    }
}
