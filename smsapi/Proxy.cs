using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public interface Proxy
    {
        void Authentication(IClient client);

        HttpResponseEntity Execute(
            ActionContentType contentType,
            string uri,
            NameValueCollection data,
            RequestMethod method);

        HttpResponseEntity Execute(
            ActionContentType contentType,
            string uri,
            NameValueCollection data,
            Stream file,
            RequestMethod method);

        HttpResponseEntity Execute(
            ActionContentType contentType,
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method);

        Task<HttpResponseEntity> ExecuteAsync(
            ActionContentType contentType,
            string uri,
            NameValueCollection data,
            RequestMethod method,
            CancellationToken cancellationToken = default
            );

        Task<HttpResponseEntity> ExecuteAsync(
            ActionContentType contentType,
            string uri,
            NameValueCollection data,
            Stream file,
            RequestMethod method,
            CancellationToken cancellationToken = default
            );

        Task<HttpResponseEntity> ExecuteAsync(
            ActionContentType contentType,
            string uri,
            NameValueCollection data,
            Dictionary<string, Stream> files,
            RequestMethod method,
            CancellationToken cancellationToken = default
            );
    }
}
