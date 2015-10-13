using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Linq;

namespace SMSApi.Api
{
    public class ProxyHTTP : Proxy
    {
        protected string baseUrl;
		Client basicAuthentication;

        public ProxyHTTP(string baseUrl) 
        {
            this.baseUrl = baseUrl;
        }

        protected Stream PrepareContent(NameValueCollection data)
        {
            Stream stream = new MemoryStream();

            IEnumerator enumerator = data.GetEnumerator();

            enumerator.Reset();

            int count = data.Keys.Count;

            foreach (string key in data.Keys)
            {
                String param = Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString(data[key]) + "&";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(param);
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

        protected Stream PrepareMultipartContent(string boundary, NameValueCollection data, Dictionary<string, Stream> files)
        {
            Stream stream = new MemoryStream();

            IEnumerator enumerator = data.GetEnumerator();

            enumerator.Reset();

            String template = Environment.NewLine + "--" + boundary + Environment.NewLine + "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment.NewLine + "{1}";

            foreach (string key in data.Keys)
            {
                string param = string.Format(template, key, data[key]);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(param);
                stream.Write(bytes, 0, bytes.Length);
            }
            
            template = 
                Environment.NewLine + "--" + boundary + Environment.NewLine +
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{0}\"" + Environment.NewLine +
                "Content-Type: application/octet-stream" + Environment.NewLine + Environment.NewLine;

            foreach( KeyValuePair<string, Stream> file in files )
            {
                string param = string.Format(template, file.Key);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(param);
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

            byte[] footBytes = System.Text.Encoding.UTF8.GetBytes(Environment.NewLine + "--" + boundary + "--");
            stream.Write(footBytes, 0, footBytes.Length);

            stream.Position = 0;

            return stream;
        }

        public Stream Execute(string uri, NameValueCollection data, string method = "POST")
        {
            Dictionary<string, Stream> files = new Dictionary<string, Stream>();
            return Execute(uri, data, files, method);
        }

        public Stream Execute(string uri, NameValueCollection data, System.IO.Stream file, string method = "POST")
        {
            Dictionary<string, Stream> files = new Dictionary<string, Stream>();
            files.Add("file", file);
            return Execute(uri, data, files, method);
        }

		public Stream Execute(string uri, NameValueCollection data, Dictionary<string, Stream> files, string method = "POST")
		{
			String boundary = "SMSAPI-" + DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") + (new Random()).Next(int.MinValue, int.MaxValue).ToString() + "-boundary";

			WebRequest webRequest = WebRequest.Create(baseUrl + uri);
			webRequest.Method = method;

			if (basicAuthentication != null)
			{
				webRequest.Headers.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(basicAuthentication.GetUsername() + ":" + basicAuthentication.GetPassword())));
			}

			if (method == "POST" || method == "PUT")
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
				catch (System.Net.WebException e)
				{
					throw new ProxyException(e.Message, e);
				}
			}

			MemoryStream response = new MemoryStream();

			try
			{
				CopyStream(webRequest.GetResponse().GetResponseStream(), response);
			}
			catch (System.Net.WebException e)
			{
				throw new ProxyException(e.Message, e);
			}

			response.Position = 0;
			return response;
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

		public void BasicAuthentication(Client client)
		{
			basicAuthentication = client;
		}
    }
}
