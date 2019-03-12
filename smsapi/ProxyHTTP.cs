using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SMSApi.Api
{
    public class ProxyHTTP : IProxy
    {
        private readonly string _baseUrl;
        private Client _basicAuthentication;

        public ProxyHTTP(string baseUrl) 
        {
            _baseUrl = baseUrl;
            if (!_baseUrl.EndsWith(@"/"))
                _baseUrl += @"/";
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

        public Stream Execute(string uri, NameValueCollection data, RequestMethod method = RequestMethod.POST)
        {
            Dictionary<string, Stream> files = new Dictionary<string, Stream>();
            return Execute(uri, data, files, method);
        }

        public Stream Execute(string uri, NameValueCollection data, Stream file, RequestMethod method = RequestMethod.POST)
        {
            var files = new Dictionary<string, Stream> {{"file", file}};
            return Execute(uri, data, files, method);
        }

		public Stream Execute(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method = RequestMethod.POST)
		{
			var boundary = $"SMSAPI-{DateTime.Now:yyyy-MM-dd_HH:mm:ss}{new Random().Next(int.MinValue, int.MaxValue)}-boundary";

			WebRequest webRequest = WebRequest.Create(_baseUrl + uri);
			webRequest.Method = RequestMethodToString(method);

			if (_basicAuthentication != null)
			{
				webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(_basicAuthentication.GetUsername() + ":" + _basicAuthentication.GetPassword())));
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

			MemoryStream response = new MemoryStream();

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

#if !NET40
        public async Task<Stream> ExecuteAsync(string uri, NameValueCollection data, RequestMethod method = RequestMethod.POST)
        {
            Dictionary<string, Stream> files = new Dictionary<string, Stream>();
            return await ExecuteAsync(uri, data, files, method);
        }

        public async Task<Stream> ExecuteAsync(string uri, NameValueCollection data, Stream file, RequestMethod method = RequestMethod.POST)
        {
            var files = new Dictionary<string, Stream> { { "file", file } };
            return await ExecuteAsync(uri, data, files, method);
        }

        public async Task<Stream> ExecuteAsync(string uri, NameValueCollection data, Dictionary<string, Stream> files, RequestMethod method = RequestMethod.POST)
        {
            var boundary = $"SMSAPI-{DateTime.Now:yyyy-MM-dd_HH:mm:ss}{new Random().Next(int.MinValue, int.MaxValue)}-boundary";

            var webRequest = WebRequest.Create(_baseUrl + uri);
            webRequest.Method = RequestMethodToString(method);

            if (_basicAuthentication != null)
            {
                webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(_basicAuthentication.GetUsername() + ":" + _basicAuthentication.GetPassword())));
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
                    var webRequestStream = await webRequest.GetRequestStreamAsync();
                    CopyStream(stream, webRequestStream);
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
                var webResponse = await webRequest.GetResponseAsync();
                var webResponseStream = webResponse.GetResponseStream();

                CopyStream(webResponseStream, response);
            }
            catch (WebException e)
            {
                throw new ProxyException("Failed to get response from " + webRequest.RequestUri, e);
            }

            response.Position = 0;
            return response;
        }

#endif

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
			_basicAuthentication = client;
		}


        private static string RequestMethodToString(RequestMethod method)
        {
            switch(method)
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
    }
}
