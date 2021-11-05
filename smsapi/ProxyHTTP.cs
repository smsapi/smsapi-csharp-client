using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

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

        public static string RequestMethodToString(RequestMethod method)
        {
            switch (method)
            {
                case RequestMethod.GET:
                    return "GET";

                case RequestMethod.PUT:
                    return "PUT";

                case RequestMethod.POST:
                    return "POST";

                case RequestMethod.DELETE:
                    return "DELETE";

                default:
                    throw new ProxyException("Invalid request method");
            }
        }

        public void Authentication(IClient client)
        {
            authentication = client;
        }

        public Stream Execute(string uri, NameValueCollection data, RequestMethod method = RequestMethod.POST)
        {
            return Execute(uri, data, new Dictionary<string, Stream>(), method);
        }

        public Stream Execute(
            string uri,
            NameValueCollection data,
            Stream file,
            RequestMethod method = RequestMethod.POST)
        {
            return Execute(uri, data, new Dictionary<string, Stream> { { "file", file } }, method);
        }

        public Stream Execute(
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method = RequestMethod.POST)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(baseUrl + uri);

            if (authentication != null)
            {
                client.UserAgent = authentication.GetClientAgentHeader();
                client.Authenticator = GetAuthenticator();
            }

            var request = new RestRequest(ToMethod(method));
            foreach (string key in data.Keys)
            {
                request.AddParameter(key, data[key]);
            }

            foreach (KeyValuePair<string, Stream> file in files)
            {
                request.AddFile(file.Key, s => file.Value.CopyTo(s), file.Key, file.Value.Length);
            }

            var responseStream = new MemoryStream();
            request.ResponseWriter = s => s.CopyTo(responseStream);

            try
            {
                client.Execute(request);
            }
            catch (System.Exception e)
            {
                throw new ProxyException("Failed to get response from " + client.BuildUri(request), e);
            }

            return responseStream;
        }

        private static Method ToMethod(RequestMethod method)
        {
            switch (method)
            {
                case RequestMethod.DELETE:
                    return Method.DELETE;

                case RequestMethod.GET:
                    return Method.GET;

                case RequestMethod.POST:
                    return Method.POST;

                case RequestMethod.PUT:
                    return Method.PUT;

                default:
                    throw new NotSupportedException();
            }
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
