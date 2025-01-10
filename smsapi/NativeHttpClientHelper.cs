using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SMSApi.Api.Action;

namespace SMSApi.Api;

public static class NativeHttpClientHelper
{
    public static async Task<HttpResponseEntity> SendRequest(
        this HttpClient httpClient,
        ActionContentType actionContentType,
        RequestMethod method,
        string uri,
        ISet<KeyValuePair<string, dynamic?>> body = null,
        Dictionary<string, Stream> files = null,
        CancellationToken cancellationToken = default
    )
    {
        HttpContent httpContent;

        switch (method)
        {
            case RequestMethod.GET:
                var getResponse = await httpClient.GetAsync(uri, cancellationToken);

                return new HttpResponseEntity(getResponse.Content.ReadAsStreamAsync(cancellationToken), getResponse.StatusCode);
            case RequestMethod.POST:
                httpContent = ConvertRequestDataToHttpContent(actionContentType, body, files);
                var postResponse = await httpClient.PostAsync(uri, httpContent, cancellationToken);

                return new HttpResponseEntity(postResponse.Content.ReadAsStreamAsync(cancellationToken), postResponse.StatusCode);
            case RequestMethod.PUT:
                httpContent = ConvertRequestDataToHttpContent(actionContentType, body, files);
                var putResponse = await httpClient.PutAsync(uri, httpContent, cancellationToken);

                return new HttpResponseEntity(putResponse.Content.ReadAsStreamAsync(cancellationToken), putResponse.StatusCode);
            case RequestMethod.DELETE:
                var deleteResult = await httpClient.DeleteAsync(uri, cancellationToken);

                return new HttpResponseEntity(deleteResult.Content.ReadAsStreamAsync(cancellationToken), deleteResult.StatusCode);
            default:
                throw new ArgumentOutOfRangeException(nameof(method), method, null);
        }
    }

    private static HttpContent ConvertRequestDataToHttpContent(
        ActionContentType contentType,
        ISet<KeyValuePair<string, dynamic?>> collection,
        Dictionary<string, Stream> files = null
    )
    {
        var collectionDictionary = collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        if (contentType == ActionContentType.Json)
            return new StringContent(JsonSerializer.Serialize(collectionDictionary), Encoding.UTF8, "application/json");

        var contentCollection = collectionDictionary.Keys
            .Select(key => new KeyValuePair<string, string>(key, collectionDictionary[key]?.ToString()))
            .ToList();

        var formUrlEncodedContent = new FormUrlEncodedContent(contentCollection);

        if (files == null || files.Count == 0) return formUrlEncodedContent;

        var streamContent = new StreamContent(files.Values.First());

        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        {
            Name = "\"file\"",
            FileName = $"\"{files.Keys.First()}\""
        };

        var content = new MultipartFormDataContent
        {
            streamContent
        };

        foreach (var keyValuePair in collection) content.Add(new StringContent(keyValuePair.Value?.ToString()), keyValuePair.Key);

        return content;
    }
}
