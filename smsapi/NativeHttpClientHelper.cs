using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public static class NativeHttpClientHelper
    {
        public static async Task<HttpResponseEntity> SendRequest(
            this HttpClient httpClient,
            RequestMethod method,
            string uri,
            NameValueCollection body = null,
            Dictionary<string, Stream> files = null,
            CancellationToken cancellationToken = default
        )
        {
            HttpContent httpContent;

            switch (method)
            {
                case RequestMethod.GET:
                    var getResponse = await httpClient.GetAsync(uri, cancellationToken);

                    return new HttpResponseEntity(getResponse.Content.ReadAsStreamAsync(), getResponse.StatusCode);
                case RequestMethod.POST:
                    httpContent = ConvertNameValueCollectionToHttpContent(body, files);
                    var postResponse = await httpClient.PostAsync(uri, httpContent, cancellationToken);

                    return new HttpResponseEntity(postResponse.Content.ReadAsStreamAsync(), postResponse.StatusCode);
                case RequestMethod.PUT:
                    httpContent = ConvertNameValueCollectionToHttpContent(body, files);
                    var putResponse = await httpClient.PutAsync(uri, httpContent, cancellationToken);

                    return new HttpResponseEntity(putResponse.Content.ReadAsStreamAsync(), putResponse.StatusCode);
                case RequestMethod.DELETE:
                    var deleteResult = await httpClient.DeleteAsync(uri, cancellationToken);

                    return new HttpResponseEntity(deleteResult.Content.ReadAsStreamAsync(), deleteResult.StatusCode);
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);
            }
        }

        private static HttpContent ConvertNameValueCollectionToHttpContent(
            NameValueCollection collection,
            Dictionary<string, Stream> files = null
        )
        {
            var contentCollectionKeys = collection.AllKeys;

            var contentCollection = contentCollectionKeys
                .Select(key => new KeyValuePair<string, string>(key, collection[key]))
                .ToList();
            var formUrlEncodedContent = new FormUrlEncodedContent(contentCollection);

            if (files == null || files.Count == 0) return formUrlEncodedContent;

            var multipartContent = new MultipartFormDataContent();

            foreach (var keyValuePair in contentCollection)
                multipartContent.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);

            files
                .ToList()
                .ForEach(pair => multipartContent.Add(new StreamContent(pair.Value), "file", pair.Key));

            return multipartContent;
        }

        public static void AddContentTypeHeader(this HttpClient httpClient, ActionContentType actionContentType)
        {
            var contentType = actionContentType switch
            {
                ActionContentType.Json => "application/json",
                ActionContentType.FormWww => "application/x-www-form-urlencoded",
                _ => throw new ArgumentOutOfRangeException(nameof(actionContentType), actionContentType, @"Not supported content type")
            };

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("content-type", contentType);
        }
    }
}
