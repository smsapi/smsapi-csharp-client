using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using SMSApi.Api.Response.Deserialization;
using smsapi.Api.Response.Deserialization.Exception;

namespace SMSApi.Api.Action;

public abstract class Action<T>
{
    protected BaseJsonDeserializer BaseJsonDeserializer = new(); //TODO remove after further refactor
    private Proxy _proxy;

    protected abstract RequestMethod Method { get; }

    protected virtual ActionContentType ContentType => ActionContentType.Json;

    protected virtual ApiType ApiType()
    {
        return Action.ApiType.Legacy;
    }

    public T Execute()
    {
        Validate();
        return ProcessResponse(_proxy.Execute(ContentType, UriWithPagination(), GetValues(), Files(), Method));
    }

    public async Task<T> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        Validate();
        return ProcessResponse(await _proxy.ExecuteAsync(ContentType, UriWithPagination(), GetValues(), Files(), Method,
            cancellationToken));
    }

    public void Proxy(Proxy proxy)
    {
        _proxy = proxy;
    }

    protected virtual Dictionary<string, Stream> Files()
    {
        return new Dictionary<string, Stream>();
    }

    protected virtual T ResponseToObject(HttpResponseEntity data) //TODO get rid of overriding
    {
        IDeserializer deserializer = ApiType() switch
        {
            Action.ApiType.Rest => new RestJsonResponseDeserializer(
                new LegacyJsonResponseDeserializer(),
                new ValidationErrorsResolver(new BaseJsonDeserializer()),
                new TooManyRequestsErrorResolver(),
                new AccessErrorResolver(),
                new NotFoundErrorResolver()
            ),
            Action.ApiType.Legacy => new LegacyJsonResponseDeserializer(),
            _ => throw new Exception("Unknown api type")
        };

        var deserializationResult = deserializer.Deserialize<T>(data);

        deserializationResult.ThrowErrors();

        return deserializationResult.Result;
    }

    protected abstract string Uri();

    protected virtual void Validate()
    {
    }

    [Obsolete($"Use {nameof(Request)}, that supports json types")]
    protected virtual NameValueCollection Values()
    {
        return new NameValueCollection();
    }

    protected virtual ISet<KeyValuePair<string, dynamic?>>? Request() => default;

    private string UriWithPagination()
    {
        var uriBuilder = new UriBuilder
        {
            Path = Uri()
        };

        AssignValuesToQuery(uriBuilder);

        if (!typeof(IPaginable).IsAssignableFrom(GetType()))
            return uriBuilder.ToPathWithQuery();

        var action = (IPaginable)this;

        return uriBuilder.ToUriWithPagination(action.Limit, action.Offset);
    }

    private void AssignValuesToQuery(UriBuilder uriBuilder)
    {
        if (!Method.Equals(RequestMethod.GET)) return;

        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        query.Add(Values());

        uriBuilder.Query = query.ToString();
    }

    private T ProcessResponse(HttpResponseEntity responseEntity)
    {
        return ResponseToObject(responseEntity);
    }

    private ISet<KeyValuePair<string, dynamic?>> GetValues()
    {
        var values = new HashSet<KeyValuePair<string, dynamic?>>
        {
            KeyValuePair.Create<string, dynamic?>("format", "json") ,
        };
        
        Request()?.Let(requestData => requestData.ToList().ForEach(data => values.Add(data)));
        
        foreach (string key in Values().AllKeys)
        {
            values.Add(KeyValuePair.Create<string, dynamic?>(key, Values().Get(key)));
        }

        return values;
    }
}
