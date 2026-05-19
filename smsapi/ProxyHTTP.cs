using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

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

            RestClient client = CreateClient();
            RestRequest request = CreateRequest(uri, data, files, method);

            try
            {
                var response = client.Execute(request);
                return ToStream(response);
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

            RestClient client = CreateClient();
            RestRequest request = CreateRequest(uri, data, files, method);

            try
            {
                var response = await client.ExecuteAsync(request);
                return ToStream(response);
            }
            catch (System.Exception e)
            {
                throw new ProxyException("Failed to get response from " + uri, e);
            }
        }

        private static Stream ToStream(RestResponse response)
        {
            var bytes = response.RawBytes ?? Array.Empty<byte>();
            return new MemoryStream(bytes, writable: false);
        }

        private static RestRequest CreateRequest(
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method)
        {
            var request = new RestRequest(uri)
            {
                Method = method.ToMethod()
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
                options.UserAgent = authentication.GetClientAgentHeader();
                options.Authenticator = GetAuthenticator();
            }

            return new RestClient(options);
        }

        private IAuthenticator GetAuthenticator()
        {
            switch (authentication)
            {
                case ClientOAuth oauth:
                    return new OAuth2AuthorizationRequestHeaderAuthenticator(oauth.Token, "Bearer");

                case Client basic:
                    return new HttpBasicAuthenticator(basic.GetUsername(), basic.GetPassword());
            }

            throw new NotSupportedException();
        }
    }
}
