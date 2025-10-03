using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public class ProxyHTTP : Proxy
    {
        private readonly string baseUrl;
        private readonly HttpClient? httpClient;
        private IClient? authentication;

        public ProxyHTTP(string baseUrl, HttpClient? httpClient = null)
        {
            this.baseUrl = baseUrl;
            this.httpClient = httpClient;
        }

        public void Authentication(IClient client)
        {
            authentication = client;
        }

        public HttpResponseEntity Execute(ActionContentType contentType, string uri, ISet<KeyValuePair<string, dynamic?>> data, RequestMethod method)
        {
            return Execute(contentType, uri, data, new Dictionary<string, Stream>(), method);
        }

        public HttpResponseEntity Execute(
            ActionContentType contentType,
            string uri,
            ISet<KeyValuePair<string, dynamic?>> data,
            Stream file,
            RequestMethod method)
        {
            return Execute(contentType, uri, data, new Dictionary<string, Stream> { { "file", file } }, method);
        }

        public HttpResponseEntity Execute(
            ActionContentType contentType,
            string uri,
            ISet<KeyValuePair<string, dynamic?>> data,
            Dictionary<string, Stream> files,
            RequestMethod method)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpClient client = CreateClient();

            try
            {
                return client.SendRequest(contentType, method, uri, data, files).Result;
            }
            catch (Exception e)
            {
                throw new ProxyException("Failed to get response from " + uri, e);
            }
        }

        public async Task<HttpResponseEntity> ExecuteAsync(
            ActionContentType contentType,
            string uri,
            ISet<KeyValuePair<string, dynamic?>> data,
            RequestMethod method,
            CancellationToken cancellationToken = default
            )
        {
            return await ExecuteAsync(contentType, uri, data, new Dictionary<string, Stream>(), method);
        }

        public async Task<HttpResponseEntity> ExecuteAsync(
            ActionContentType contentType,
            string uri,
            ISet<KeyValuePair<string, dynamic?>> data,
            Stream file,
            RequestMethod method,
            CancellationToken cancellationToken = default
            )
        {
            return await ExecuteAsync(contentType, uri, data, new Dictionary<string, Stream> { { "file", file } }, method);
        }

        public async Task<HttpResponseEntity> ExecuteAsync(
            ActionContentType contentType,
            string uri,
            ISet<KeyValuePair<string, dynamic?>> data,
            Dictionary<string, Stream> files,
            RequestMethod method,
            CancellationToken cancellationToken = default
            )
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpClient client = CreateClient();

            try
            {
                return await client.SendRequest(contentType, method, uri, data, files, cancellationToken);
            }
            catch (Exception e)
            {
                throw new ProxyException("Failed to get response from " + uri, e);
            }
        }

        private HttpClient CreateClient()
        {
            var client = httpClient ?? new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            if (authentication == null) return client;

            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", authentication.GetClientAgent());

            var authHeader = authentication.DefaultRequestHeaders;

            client.DefaultRequestHeaders.Add(authHeader.Key, authHeader.Value);

            return client;
        }
    }
}
