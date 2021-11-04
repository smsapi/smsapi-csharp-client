﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace SMSApi.Api
{
    public class ProxyHTTP : Proxy
    {
        //private const SecurityProtocolType _Tls11 = (SecurityProtocolType)0x00000300;
        private const SecurityProtocolType _Tls12 = (SecurityProtocolType)0x00000C00;

        protected string baseUrl;
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
            var files = new Dictionary<string, Stream>();
            return Execute(uri, data, files, method);
        }

        public Stream Execute(
            string uri,
            NameValueCollection data,
            Stream file,
            RequestMethod method = RequestMethod.POST)
        {
            var files = new Dictionary<string, Stream>();
            files.Add("file", file);
            return Execute(uri, data, files, method);
        }

        public Stream Execute(
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method = RequestMethod.POST)
        {
            string boundary = "SMSAPI-" + DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss")
                + new Random().Next(int.MinValue, int.MaxValue) + "-boundary";

            ServicePointManager.SecurityProtocol = _Tls12;
            var webRequest = WebRequest.Create(baseUrl + uri);
            webRequest.Method = RequestMethodToString(method);

            if (authentication != null)
            {
                webRequest.Headers.Add("Authorization", authentication.GetAuthenticationHeader());

                var httpRequest = webRequest as HttpWebRequest;
                if (httpRequest != null)
                {
                    httpRequest.UserAgent = authentication.GetClientAgentHeader();
                }
            }

            if (RequestMethod.POST.Equals(method) || RequestMethod.PUT.Equals(method))
            {
                Stream stream;

                if (files != null && files.Count > 0)
                {
                    webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
                    stream = PrepareMultipartContent(boundary, data, files);
                }
                else
                {
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    stream = PrepareContent(data);
                }

                webRequest.ContentLength = stream.Length;

                try
                {
                    stream.Position = 0;
                    CopyStream(stream, webRequest.GetRequestStream());
                    stream.Close();
                }
                catch (WebException e)
                {
                    throw new ProxyException(e.Message, e);
                }
            }

            var response = new MemoryStream();

            try
            {
                CopyStream(webRequest.GetResponse().GetResponseStream(), response);
            }
            catch (WebException e)
            {
                throw new ProxyException("Failed to get response from " + webRequest.RequestUri, e);
            }

            response.Position = 0;
            return response;
        }

        protected Stream PrepareContent(NameValueCollection data)
        {
            Stream stream = new MemoryStream();

            IEnumerator enumerator = data.GetEnumerator();

            enumerator.Reset();

            int count = data.Keys.Count;

            foreach (string key in data.Keys)
            {
                string param = Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString(data[key]) + "&";
                byte[] bytes = Encoding.UTF8.GetBytes(param);
                stream.Write(bytes, 0, bytes.Length);
            }

            if (stream.Length > 0)
            {
                //remove the "&" at the end
                stream.SetLength(stream.Length - 1);
            }

            stream.Position = 0;

            return stream;
        }

        protected Stream PrepareMultipartContent(
            string boundary,
            NameValueCollection data,
            Dictionary<string, Stream> files)
        {
            Stream stream = new MemoryStream();

            IEnumerator enumerator = data.GetEnumerator();

            enumerator.Reset();

            string template = Environment.NewLine + "--" + boundary + Environment.NewLine
                + "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment.NewLine + "{1}";

            foreach (string key in data.Keys)
            {
                string param = string.Format(template, key, data[key]);
                byte[] bytes = Encoding.UTF8.GetBytes(param);
                stream.Write(bytes, 0, bytes.Length);
            }

            template =
                Environment.NewLine + "--" + boundary + Environment.NewLine +
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{0}\"" + Environment.NewLine +
                "Content-Type: application/octet-stream" + Environment.NewLine + Environment.NewLine;

            foreach (KeyValuePair<string, Stream> file in files)
            {
                string param = string.Format(template, file.Key);
                byte[] bytes = Encoding.UTF8.GetBytes(param);
                stream.Write(bytes, 0, bytes.Length);

                Stream fileStream = file.Value;
                fileStream.Position = 0;
                byte[] buffer = new byte[1024];
                int bytesRead = 0;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }

            byte[] footBytes = Encoding.UTF8.GetBytes(Environment.NewLine + "--" + boundary + "--");
            stream.Write(footBytes, 0, footBytes.Length);

            stream.Position = 0;

            return stream;
        }

        private void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[2048];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
    }
}
